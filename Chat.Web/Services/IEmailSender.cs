using System.Threading.Tasks;

namespace dotnetcorechat.Services 
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}