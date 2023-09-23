using Labs.Application.Contract;
using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;
using Labs.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Labs.Application.UseCases.Transactions
{
    public class GetByIdUseCase : IGetByIdUseCase
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<GetByIdUseCase> _logger;

        public GetByIdUseCase(ITransactionRepository transactionRepository, ILogger<GetByIdUseCase> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<UseCaseResponseContract<Transaction>> Handle(Guid transactionId)
        {
            var result = new UseCaseResponseContract<Transaction>();

            try
            {
                var transaction = await _transactionRepository.GetTransactionById(transactionId);

                result.Data = transaction;
            }
            catch(Exception ex)
            {
                _logger.LogError("{transactionId} {exception}", transactionId, ex.Message);
            }

            return result;
        }
    }
}
