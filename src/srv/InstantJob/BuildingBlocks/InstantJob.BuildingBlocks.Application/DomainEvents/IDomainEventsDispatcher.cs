using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.DomainEvents
{
    public interface IDomainEventsDispatcher
    {
        Task DispatchDomainEvents();
    }
}
