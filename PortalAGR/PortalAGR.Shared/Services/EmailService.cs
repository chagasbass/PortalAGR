using System.Threading.Tasks;

namespace PortalAGR.Shared.Services
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmail(string emailTo, string username, string emailText)
        {
            return true;
        }
    }
}
