namespace Halan.Common
{
    public class CustomException : Exception
    {
        public int Code;
        public object Errors;

        public CustomException(int code, string message, object Errors) : base(message)
        {
            Code = code;
            this.Errors = Errors;
        }
    }
}
