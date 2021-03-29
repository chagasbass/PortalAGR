using MediatR;
using PortalAGR.Shared.Commands;
using System.Threading.Tasks;

namespace PortalAGR.Shared.QueueHandlers
{
    public class QueueHandler : IQueueHandler
    {
        private readonly Mediator _mediator;

        public QueueHandler(Mediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ICommandResult> SendCommand<T>(T command) where T : ICommand
        {
            var commandResult = (CommandResult)await _mediator.Send(command);

            return commandResult;
        }
    }
}
