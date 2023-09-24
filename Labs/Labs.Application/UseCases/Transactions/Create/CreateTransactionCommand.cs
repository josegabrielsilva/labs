using Labs.Application.Contract;
using MediatR;

namespace Labs.Application.UseCases.Transactions
{
    public class CreateTransactionCommand : IRequest<UseCaseResponseContract<Guid>>
    {
        public Guid Merchant { get; set; }
        public double SaleValue { get; set; }
    }
}
