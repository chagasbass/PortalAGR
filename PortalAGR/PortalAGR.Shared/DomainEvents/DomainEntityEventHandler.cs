using MediatR;
using System.Threading.Tasks;

namespace PortalAGR.Shared.DomainEvents
{
    public class DomainEntityEventHandler : IDomainEntityEventHandler<IDomainEntityEvent>
    {
        private readonly Mediator _mediator;

        public DomainEntityEventHandler(Mediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Raise(IDomainEntityEvent domainEvent) => await _mediator.Publish(domainEvent);
    }
}
