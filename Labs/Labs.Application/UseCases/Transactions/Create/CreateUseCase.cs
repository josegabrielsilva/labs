using Labs.Application.Contract;
using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;
using Labs.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Labs.Application.UseCases.Transactions.Create
{
    public class CreateUseCase : ICreateUseCase
    {
        private readonly ILogger<CreateUseCase> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public CreateUseCase(ITransactionRepository transactionRepository, ILogger<CreateUseCase> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<UseCaseResponseContract<Guid>> Handle(Guid merchant, double saleValue)
        {
            var result = new UseCaseResponseContract<Guid>();

            try
            {
                var transaction = new Transaction(merchant, saleValue);

                var response = await _transactionRepository.Create(transaction);

                result.Data = response;
            }
            catch(EntityValidationException ex)
            {
                result.ValidationMessages.Add(new ResultMessage("X", ex.Message));            
            }
            catch(Exception ex)
            {
                result.ProcessingErrorMessages.Add(new ResultMessage("X", ex.Message));
                _logger.LogError("{merchant} {exception}", merchant, ex);
            }

            return result;
        }
    }
}
