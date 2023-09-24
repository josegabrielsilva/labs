using Labs.Domain.Entities;

namespace Labs.Infrastructure.Contracts.Api.Transactions
{
    public static class TransactionMappers
    {
        public static GetTransactionResponse ToApiResponseContract(this Transaction transaction)
            => new (transaction.SaleValue, transaction.Merchant);

        public static List<GetTransactionResponse> ToApiResponseContract(this List<Transaction> transactions)
            => transactions.Select(transaction => 
                new GetTransactionResponse(transaction.SaleValue, transaction.Merchant)).ToList();
    }
}
