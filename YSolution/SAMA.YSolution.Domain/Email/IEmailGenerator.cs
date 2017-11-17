using System.Net.Mail;

namespace SAMA.YSolution.Domain.Email
{
    public interface IEmailGenerator
    {
        MailMessage Generate(object objHolder, EmailTemplate emailTemplate);
    }
}