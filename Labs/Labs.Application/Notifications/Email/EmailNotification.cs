using MediatR;

namespace Labs.Application.Notifications.Email
{
    public class EmailNotification : INotification
    {
        public EmailNotification(string message) => Message = message;

        public string Message { get; private set; }
    }
}
