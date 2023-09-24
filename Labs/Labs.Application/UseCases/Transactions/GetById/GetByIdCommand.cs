using Labs.Application.Contract;
using Labs.Domain.Entities;
using MediatR;

namespace Labs.Application.UseCases.Transactions
{
    public class GetByIdCommand : IRequest<UseCaseResponseContract<Transaction>>
    {
        public GetByIdCommand(Guid transactionId)
        {
            TransactionId = transactionId;
        }
        public Guid TransactionId { get; set; }
    }
}
