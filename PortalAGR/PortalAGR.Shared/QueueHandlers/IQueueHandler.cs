using PortalAGR.Shared.Commands;
using System.Threading.Tasks;

namespace PortalAGR.Shared.QueueHandlers
{
    public interface IQueueHandler
    {
        Task<ICommandResult> SendCommand<T>(T command) where T : ICommand;
    }
}
