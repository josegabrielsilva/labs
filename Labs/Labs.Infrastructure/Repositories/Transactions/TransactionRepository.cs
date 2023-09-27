using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;

namespace Labs.Infrastructure.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private static readonly List<Transaction> TransactionsStorage = new();

        public Task<Guid> Create(Transaction transaction, CancellationToken cancellationToken)
        {
            TransactionsStorage.Add(transaction);
            return Task.FromResult(transaction.TransactionId);
        } 

        public async Task<Transaction?> GetTransactionById(Guid transactionId, CancellationToken cancellationToken)
            => await Task.FromResult(TransactionsStorage.FirstOrDefault(
                        transaction => transaction?.TransactionId == transactionId, null));

        public async Task<IEnumerable<Transaction>> GetTransactionByPeriod(DateTime initial, DateTime final, CancellationToken cancellationToken)
            => await Task.FromResult(TransactionsStorage.Where(x => 
                    x.Date.Date.ToLocalTime().Date >= initial.Date
                    && x.Date.ToLocalTime().Date <= final.Date)
                );
    }
}
