namespace Labs.Application.Services.Email
{
    public interface IEmailService
    {
        void Send(EmailModel emailModel);
    }
}
