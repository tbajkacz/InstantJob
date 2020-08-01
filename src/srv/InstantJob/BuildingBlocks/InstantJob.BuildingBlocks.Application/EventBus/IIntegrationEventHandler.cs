using MediatR;

namespace InstantJob.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEventHandler<in TEvent> : INotificationHandler<TEvent>
        where TEvent : IIntegrationEvent
    {
    }
}
