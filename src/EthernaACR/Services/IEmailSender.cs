using System.Threading.Tasks;

namespace Etherna.ACR.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
