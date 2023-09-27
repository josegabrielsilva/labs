using Labs.Domain.Entities;

namespace Labs.Application.Repositories.Transactions
{
    public interface ITransactionRepository
    {
        Task<Guid> Create(Transaction transaction, CancellationToken cancellationToken);
        Task<Transaction?> GetTransactionById(Guid transactionId, CancellationToken cancellationToken);
        Task<IEnumerable<Transaction>> GetTransactionByPeriod(DateTime initial, DateTime final, CancellationToken cancellationToken);
    }
}
