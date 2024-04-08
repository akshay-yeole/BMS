using StatusCodes = BMS.Domain.Constants.StatusCodes;

namespace BMS.Core.Common
{
    public class Result
    {
        public bool IsSuccess { get; set; }
        public string StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; protected set; }
        public bool IsFailure
        {
            get
            {
                return !IsSuccess;
            }
        }

        public Result(bool succeded, string statusCode, string message = "")
        {
            IsSuccess = succeded;
            StatusCode = statusCode;
            ErrorMessage = message;
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value);
        }

        public static Result<T> Ok<T>(T value, string statusCode)
        {
            return new Result<T>(value, statusCode);
        }

        public static Result<T> Fail<T>(string errorMessage, string statusCode)
        {
            return new Result<T>(errorMessage, statusCode);
        }
    }
    public class Result<T> : Result
    {
        private readonly T _value;

        public T Value
        {
            get
            {
                if (IsFailure)
                    throw new AggregateException();
                return _value;
            }
        }

        public Result(T value, string statusCode = StatusCodes.StandardSuccessCode) : base(true, statusCode, string.Empty)
        {
            if (value == null)
            {
                IsSuccess = false;
                Exception = new NullReferenceException();
            }
            else
            {
                _value = value;
                Exception = null;
            }
        }

        public Result(string errorMessage, string erroCode) : base(false, erroCode, errorMessage)
        {
            _value = default(T);
            Exception = new Exception();
        }
    }
}
