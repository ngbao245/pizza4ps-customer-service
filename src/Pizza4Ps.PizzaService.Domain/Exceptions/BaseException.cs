namespace Pizza4Ps.PizzaService.Domain.Exceptions
{
    public abstract class BaseException : Exception
    {
        public int ErrorCode { get; }
        public BaseException(string message, int errorCode) : base(message)
        {
            ErrorCode = errorCode;
        }
    }

    public class ValidationException : BaseException
    {
        public ValidationException(string message, int errorCode = 1001)
            : base(message, errorCode) { }
    }

    public class BusinessException : BaseException
    {
        public BusinessException(string message, int errorCode = 1002)
            : base(message, errorCode) { }
    }

    public class NotFoundException : BaseException
    {
        public NotFoundException(string message, int errorCode = 1003)
            : base(message, errorCode) { }
    }

    public class ServerException : BaseException
    {
        public ServerException(string message, int errorCode = 5000)
            : base(message, errorCode) { }
    }

}
