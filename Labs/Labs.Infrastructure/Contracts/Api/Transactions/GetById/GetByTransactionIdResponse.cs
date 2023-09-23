namespace Labs.Infrastructure.Contracts.Api.Transactions
{
    public class GetByTransactionIdResponse
    {
        public GetByTransactionIdResponse(double saleValue, Guid merchant)
        {
            SaleValue = saleValue;
            Merchant = merchant;
        }
        public double SaleValue { get; set; }
        public Guid Merchant { get; set; }
    }
}
