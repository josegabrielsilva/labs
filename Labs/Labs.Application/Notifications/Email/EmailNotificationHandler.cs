using MediatR;
using Microsoft.Extensions.Logging;

namespace Labs.Application.Notifications.Email
{
    public class EmailNotificationHandler : INotificationHandler<EmailNotification>
    {
        private readonly ILogger<EmailNotificationHandler> _logger;

        public EmailNotificationHandler(ILogger<EmailNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(EmailNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Mensagem {notification.Message} enviada por E-mail");

            return Task.CompletedTask;
        }
    }
}
