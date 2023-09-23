using Labs.Application.Contract;

namespace Labs.Application.UseCases.Transactions.Create
{
    public interface ICreateUseCase
    {
        Task<UseCaseResponseContract<Guid>> Handle(Guid merchant, double saleValue);
    }
}
