namespace Labs.Application.Models
{
    public class ProcessServiceResponse<T>
    {
        public IDictionary<string, string> ValidationMessages { get; set; } =
            new Dictionary<string, string>();

        public IDictionary<string, string> ErrorMessages { get; set; } = 
            new Dictionary<string, string>();

        public bool Success
        {
            private set { Success = ErrorMessages.Any() || ValidationMessages.Any(); }
            get { return Success; }
        }

        public T Data { get; set; }
    }
}
