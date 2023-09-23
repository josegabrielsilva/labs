using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;

namespace Labs.Infrastructure.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private static readonly List<Transaction> TransactionsStorage = new();

        public Task<Guid> Create(Transaction transaction)
        {
            TransactionsStorage.Add(transaction);
            return Task.FromResult(transaction.TransactionId);
        } 

        public async Task<Transaction?> GetTransactionById(Guid transactionId)
            => await Task.FromResult(
                TransactionsStorage.FirstOrDefault(
                        transaction => transaction?.TransactionId == transactionId, null
                    )
                );
        
    }
}
