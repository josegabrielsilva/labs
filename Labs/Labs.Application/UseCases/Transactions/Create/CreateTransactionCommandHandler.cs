using Labs.Application.Contract;
using Labs.Application.Notifications.Email;
using Labs.Application.Notifications.Sms;
using Labs.Application.Repositories.Transactions;
using Labs.Domain.Entities;
using Labs.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Labs.Application.UseCases.Transactions
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, UseCaseResponseContract<Guid>>
    {
        private readonly ILogger<CreateTransactionCommandHandler> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMediator _mediator;
        public CreateTransactionCommandHandler(
            ITransactionRepository transactionRepository, 
            ILogger<CreateTransactionCommandHandler> logger,
            IMediator mediator)
        {
            _transactionRepository = transactionRepository;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task<UseCaseResponseContract<Guid>> Handle(CreateTransactionCommand command, CancellationToken cancellationToken)
        {
            var result = new UseCaseResponseContract<Guid>();

            try
            {
                var transaction = new Transaction(command.Merchant, command.SaleValue);

                var response = await _transactionRepository.Create(transaction);

                result.Data = response;

                await _mediator.Publish(new EmailNotification("Teste"));
                await _mediator.Publish(new SmsNotification("Teste"));
            }
            catch(EntityValidationException ex)
            {
                result.ValidationMessages.Add(new ResultMessage("X", ex.Message));            
            }
            catch(Exception ex)
            {
                result.ProcessingErrorMessages.Add(new ResultMessage("X", ex.Message));
                _logger.LogError("{merchant} {exception}", command.Merchant, ex);
            }

            return result;
        }
    }
}
