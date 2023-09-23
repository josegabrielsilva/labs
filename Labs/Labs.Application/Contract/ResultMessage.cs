namespace Labs.Application.Contract
{
    public sealed class ResultMessage
    {
        public string Field { get; set; }
        public string Description { get; set; }
        public ResultMessage(string field, string description)
        {
            Field = field;
            Description = description;
        }
    }


}
