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
            => await Task.FromResult(TransactionsStorage.FirstOrDefault(
                        transaction => transaction?.TransactionId == transactionId, null));

        public async Task<IEnumerable<Transaction>> GetTransactionByPeriod(DateTime initial, DateTime final)
            => await Task.FromResult(TransactionsStorage.Where(x => x.Date >= initial && x.Date <= final));
    }
}
