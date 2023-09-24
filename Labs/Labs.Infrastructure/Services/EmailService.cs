using Labs.Application.Services.Email;
using MailKit.Net.Smtp;
using MimeKit;

namespace Labs.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public void Send(EmailModel emailModel)
        {
            // Configurações do servidor SMTP
            string smtpServer = "smtp.gmail.com"; // Substitua pelo seu servidor SMTP
            int smtpPort = 587; // Porta SMTP padrão é 587
            string smtpUsername = "josegabrielsilva1707@gmail.com"; // Seu endereço de e-mail
            string smtpPassword = "08102812forte"; // Sua senha de e-mail

            // Criar uma mensagem de e-mail
            var mensagem = new MimeMessage();
            mensagem.From.Add(new MailboxAddress("Remetente", "josegabrielsilva1707@gmail.com")); // Remetente
            mensagem.To.Add(new MailboxAddress("Destinatário", "josegabrielsilva1707@hotmail.com")); // Destinatário
            mensagem.Subject = "Assunto do E-mail";
            mensagem.Body = new TextPart("plain")
            {
                Text = "Corpo do E-mail"
            };

            // Configurar o cliente SMTP
            using (var clienteSmtp = new SmtpClient())
            {
                clienteSmtp.Connect(smtpServer, smtpPort, false);
                clienteSmtp.Authenticate(smtpUsername, smtpPassword);

                // Enviar o e-mail
                clienteSmtp.Send(mensagem);

                // Desconectar do servidor SMTP
                clienteSmtp.Disconnect(true);
            }
        }
    }
}
