using System.Net.Mail;

namespace SAMA.YSolution.Domain.Email
{
    public interface IEmailDispatcher
    {
        void Dispatch(MailMessage mailMessage);
    }
}