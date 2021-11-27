using System.Threading.Tasks;

namespace Etherna.SSL.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
