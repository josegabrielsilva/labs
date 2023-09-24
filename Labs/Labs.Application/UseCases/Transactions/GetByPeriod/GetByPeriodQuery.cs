using Labs.Application.Contract;
using Labs.Domain.Entities;
using MediatR;

namespace Labs.Application.UseCases.Transactions.GetByPeriod
{
    public class GetByPeriodQuery : IRequest<UseCaseResponseContract<List<Transaction>>>
    {
        public GetByPeriodQuery(DateTime initial, DateTime final)
        {
            Initial = initial;
            Final = final;
        }
        public DateTime Initial { get; set; }
        public DateTime Final { get; set; }
    }
}
