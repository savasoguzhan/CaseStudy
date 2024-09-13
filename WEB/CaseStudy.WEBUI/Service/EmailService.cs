using CaseStudy.WEBUI.Helper;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;


namespace CaseStudy.WEBUI.Service
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _options;

        public EmailService(IOptions<EmailSettings> options)
        {
            _options = options.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_options.Email);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailRequest.Body;

            email.Body= builder.ToMessageBody();

            using var smtp = new SmtpClient();
            smtp.Connect(_options.Host, _options.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(_options.Email, _options.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
            
        
        }
    }
}
