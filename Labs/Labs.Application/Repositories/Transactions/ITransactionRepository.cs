using Labs.Domain.Entities;

namespace Labs.Application.Repositories.Transactions
{
    public interface ITransactionRepository
    {
        Task<Guid> Create(Transaction transaction);
        Task<Transaction?> GetTransactionById(Guid transactionId);
        Task<IEnumerable<Transaction>> GetTransactionByPeriod(DateTime initial, DateTime final);
    }
}
