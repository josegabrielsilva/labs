using MediatR;
using Microsoft.Extensions.Logging;

namespace Labs.Application.Notifications.Sms
{
    public class SmsNotificationHandler : INotificationHandler<SmsNotification>
    {

        private readonly ILogger<SmsNotificationHandler> _logger;

        public SmsNotificationHandler(ILogger<SmsNotificationHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(SmsNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Mensagem {notification.Message} enviada por SMS");

            return Task.CompletedTask;
        }
    }
}
