using System.Threading.Tasks;

namespace Etherna.RCL.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
