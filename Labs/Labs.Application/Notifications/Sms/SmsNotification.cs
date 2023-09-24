using MediatR;

namespace Labs.Application.Notifications.Sms
{
    public class SmsNotification : INotification
    {
        public SmsNotification(string message) => Message = message;

        public string Message { get; set; } 
    }
}
