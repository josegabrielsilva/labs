using Labs.Application.Contract;
using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Labs.Application.UseCases.Transactions
{
    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, UseCaseResponseContract<Transaction>>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<GetByIdQueryHandler> _logger;

        public GetByIdQueryHandler(ITransactionRepository transactionRepository, ILogger<GetByIdQueryHandler> logger)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
        }

        public async Task<UseCaseResponseContract<Transaction>> Handle(GetByIdQuery command, CancellationToken cancellationToken)
        {
            var result = new UseCaseResponseContract<Transaction>();

            try
            {
                var transaction = await _transactionRepository.GetTransactionById(command.TransactionId);

                result.Data = transaction;
            }
            catch(Exception ex)
            {
                _logger.LogError("{transactionId} {exception}", command.TransactionId, ex.Message);
            }

            return result;
        }
    }
}
