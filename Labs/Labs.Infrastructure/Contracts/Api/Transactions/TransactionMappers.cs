using Labs.Domain.Entities;

namespace Labs.Infrastructure.Contracts.Api.Transactions
{
    public static class TransactionMappers
    {
        public static GetByTransactionIdResponse ToApiResponseContract(this Transaction transaction)
            => new GetByTransactionIdResponse(transaction.SaleValue, transaction.Merchant);
    }
}
