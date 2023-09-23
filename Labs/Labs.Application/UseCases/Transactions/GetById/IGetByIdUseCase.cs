using Labs.Application.Contract;
using Labs.Domain.Entities;

namespace Labs.Application.UseCases.Transactions
{
    public interface IGetByIdUseCase
    {
        Task<UseCaseResponseContract<Transaction>> Handle(Guid transactionId);
    }
}
