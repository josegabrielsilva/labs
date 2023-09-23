namespace Labs.Application.Contract
{
    public class UseCaseResponseContract<T>
    {
        public UseCaseResponseContract()
        {
            ValidationMessages = new List<ResultMessage>();
            ProcessingErrorMessages = new List<ResultMessage>();
        }

        public T? Data { get; set; }
        public List<ResultMessage> ValidationMessages { get; set; }
        public List<ResultMessage> ProcessingErrorMessages { get; set; }
        public bool ProcessedWithSuccess => !ValidationMessages.Any() || !ProcessingErrorMessages.Any();
    }
}
