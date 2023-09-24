using Labs.Application.Contract;
using Labs.Domain.Entities;
using MediatR;

namespace Labs.Application.UseCases.Transactions
{
    public class GetByIdQuery : IRequest<UseCaseResponseContract<Transaction>>
    {
        public GetByIdQuery(Guid transactionId)
        {
            TransactionId = transactionId;
        }
        public Guid TransactionId { get; set; }
    }
}
