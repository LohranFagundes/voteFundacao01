using AppVote01.Data.Dtos;
using MailKit.Net.Smtp;
using MimeKit;

namespace AppVote01.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void EnviarEmail(EmailDto emailDto)
        {
            var mensagem = new MimeMessage();
            mensagem.From.Add(MailboxAddress.Parse(emailDto.Remetente));
            mensagem.To.Add(MailboxAddress.Parse(emailDto.Destinatario));
            mensagem.Subject = emailDto.Assunto;
            mensagem.Body = new TextPart("plain")
            {
                Text = emailDto.Corpo
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_configuration["Email:Host"], int.Parse(_configuration["Email:Port"]), bool.Parse(_configuration["Email:UseSsl"]));
                client.Authenticate(_configuration["Email:Username"], _configuration["Email:Password"]);
                client.Send(mensagem);
                client.Disconnect(true);
            }
        }
    }
}