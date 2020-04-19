namespace SparkEquation.Trial.WebAPI.Services.Communication
{
    public class BaseResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public BaseResponse()
        {
            Success = true;
            Message = string.Empty;
        }

        public BaseResponse(string message)
        {
            Success = false;
            Message = message;
        }
    }
}
