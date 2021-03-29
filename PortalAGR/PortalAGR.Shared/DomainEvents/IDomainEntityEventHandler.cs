using System.Threading.Tasks;

namespace PortalAGR.Shared.DomainEvents
{
    public interface IDomainEntityEventHandler<T>
    {
        Task Raise(T domainEvent);
    }
}
