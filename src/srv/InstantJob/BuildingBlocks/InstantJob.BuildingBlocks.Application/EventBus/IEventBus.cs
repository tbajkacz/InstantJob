using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.EventBus
{
    public interface IEventBus
    {
        Task PublishAsync(string key, string message);

        void Subscribe<THandler>(string key)
            where THandler : IIntegrationEventHandler;
    }
}
