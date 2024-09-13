using CaseStudy.WEBUI.Helper;

namespace CaseStudy.WEBUI.Service
{
    public interface IEmailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
