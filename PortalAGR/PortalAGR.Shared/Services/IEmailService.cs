using System.Threading.Tasks;

namespace PortalAGR.Shared.Services
{
    public interface IEmailService
    {
        Task<bool> SendEmail(string emailTo, string username, string emailText);
    }
}
