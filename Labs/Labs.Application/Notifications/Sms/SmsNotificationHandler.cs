using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs.Application.Notifications.Sms
{
    public class SmsNotificationHandler : INotificationHandler<SmsNotification>
    {
        public Task Handle(SmsNotification notification, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Mensagem {notification.Message} enviada por SMS");
            return Task.CompletedTask;
        }
    }
}
