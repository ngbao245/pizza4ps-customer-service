using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Net;
using System.Text.Json;
using ValidationException = Pizza4Ps.PizzaService.Domain.Exceptions.ValidationException;

namespace Pizza4Ps.PizzaService.API.Middlewares
{
    public class ExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(RequestDelegate next, ILogger<ExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BaseException ex)
            {
                await HandleBaseExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "An unexpected error occurred.");
                await HandleExceptionAsync(context, HttpStatusCode.InternalServerError, "An unexpected error occurred.", ex.Message);
            }
        }
        private async Task HandleBaseExceptionAsync(HttpContext context, BaseException ex)
        {
            HttpStatusCode statusCode = ex switch
            {
                ValidationException => HttpStatusCode.UnprocessableEntity,
                BusinessException => HttpStatusCode.BadRequest,
                NotFoundException => HttpStatusCode.NotFound,
                ServerException => HttpStatusCode.InternalServerError,
                _ => HttpStatusCode.BadRequest
            };
            var exceptionName = ex switch
            {
                ValidationException => nameof(ValidationException),
                BusinessException => nameof(BusinessException),
                NotFoundException => nameof(NotFoundException),
                ServerException => nameof(ServerException),
                _ => nameof(BaseException)
            };
            //_logger.LogWarning(ex, "A known error occurred: {ErrorCode} - {Message}", ex.ErrorCode, ex.Message);

            await HandleExceptionAsync(context, statusCode, exceptionName, ex.Message, ex.ErrorCode);
        }

        private Task HandleExceptionAsync(HttpContext context, HttpStatusCode statusCode, string title, string message, int? errorCode = null)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var response = new
            {
                error = new
                {
                    code = errorCode ?? 500,
                    title = title,
                    message,
                    statusCode = context.Response.StatusCode,
                    timestamp = DateTimeOffset.UtcNow
                }
            };
            return context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

    }
}
