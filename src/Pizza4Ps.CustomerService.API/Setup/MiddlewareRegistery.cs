using Pizza4Ps.CustomerService.API.Middlewares;

namespace Pizza4Ps.CustomerService.API.Setup
{
    public static class MiddlewareRegistery
    {
        public static IApplicationBuilder MiddlewareRegisteryMethod(this IApplicationBuilder app)
        {
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "swagger"; // Cấu hình để Swagger UI chạy tại /swagger
            }); ;
            app.UseMiddleware<ExceptionHandler>();
            app.UseCors("AllowAll");
            return app;
        }
    }
}
