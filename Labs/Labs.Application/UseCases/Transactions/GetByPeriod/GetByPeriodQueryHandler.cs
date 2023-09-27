using Labs.Application.Contract;
using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Labs.Application.UseCases.Transactions.GetByPeriod
{
    public class GetByPeriodQueryHandler : IRequestHandler<GetByPeriodQuery, UseCaseResponseContract<List<Transaction>>>
    {
        private readonly ILogger<GetByPeriodQueryHandler> _logger;
        private readonly ITransactionRepository _transactionRepository;

        public GetByPeriodQueryHandler(
            ILogger<GetByPeriodQueryHandler> logger, 
            ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }

        public async Task<UseCaseResponseContract<List<Transaction>>> Handle(
            GetByPeriodQuery request, 
            CancellationToken cancellationToken)
        {
            var result = new UseCaseResponseContract<List<Transaction>>();

            try
            {
                var response = await _transactionRepository.GetTransactionByPeriod(
                    request.Initial, request.Final, cancellationToken);

                result.Data = response.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("{exceptionMessage}", ex);
            }
            
            return result;
        }
    }
}
