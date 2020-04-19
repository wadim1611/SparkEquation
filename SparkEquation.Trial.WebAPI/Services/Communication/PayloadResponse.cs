namespace SparkEquation.Trial.WebAPI.Services.Communication
{
    public class PayloadResponse<T> : BaseResponse
    {
        public T Resource { get; private set; }

        public PayloadResponse(T resource) : base()
        {
            Resource = resource;
        }

        public PayloadResponse(string message) : base(message)
        {
            Resource = default;
        }
    }
}
