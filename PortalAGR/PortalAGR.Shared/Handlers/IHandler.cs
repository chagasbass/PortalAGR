using PortalAGR.Shared.Commands;
using System.Threading.Tasks;

namespace PortalAGR.Shared.Handlers
{
    public interface IHandler
    {
        Task<ICommandResult> SendComand<T>(T command) where T : ICommand;
    }
}
