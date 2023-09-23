using Labs.Domain.Entities;

namespace Labs.Application.Repositories.Transactions
{
    public interface ITransactionRepository
    {
        Task<Guid> Create(Transaction transaction);
        Task<Transaction?> GetTransactionById(Guid transactionId);
    }
}
