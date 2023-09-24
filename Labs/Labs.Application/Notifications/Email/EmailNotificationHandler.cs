﻿using Labs.Application.Services.Email;
using MediatR;

namespace Labs.Application.Notifications.Email
{
    public class EmailNotificationHandler : INotificationHandler<EmailNotification>
    {
        private readonly IEmailService _emailService;

        public EmailNotificationHandler(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public Task Handle(EmailNotification notification, CancellationToken cancellationToken)
        {
            _emailService.Send(new EmailModel());
            Console.WriteLine($"Mensagem {notification.Message} enviada por E-mail");

            return Task.CompletedTask;
        }
    }
}