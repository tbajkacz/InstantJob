using MediatR;

namespace InstantJob.BuildingBlocks.Domain
{
    public interface IDomainEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IDomainEvent
    {
    }
}
