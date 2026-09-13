

namespace NibbssNPSPaymentStack.Business.Models.Response
{
    public class CustomResult<T>
    {
        private readonly T? _value;

        private CustomResult(T value,string message)
        {
            data = value;
            Succeeded = true;
            Error = CustomError.None;
            Message = message;
        }

        private CustomResult(CustomError error)
        {
            if (error == CustomError.None)
            {
                throw new ArgumentException("Invalid error", nameof(error));
            }


            Succeeded = false;
            Error = error;
        }


        public bool Succeeded { get; }
        public string Message { get; }
        //public bool IsFailure => !Succeeded;

        public T data
        {
            get
            {
                return _value!;
            }

            private init => _value = value;
        }

        public CustomError Error { get; }
        public static CustomResult<T> Success(T value,string message)
        {
            return new CustomResult<T>(value,message);
        }
        public static CustomResult<T> Failure(CustomError error)
        {
            return new CustomResult<T>(error);
        }
    }
}
