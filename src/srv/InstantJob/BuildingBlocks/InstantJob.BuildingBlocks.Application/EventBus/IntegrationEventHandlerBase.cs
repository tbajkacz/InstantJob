using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEventHandler
    {
        Task Invoke(string message);
    }

    public abstract class IntegrationEventHandlerBase<T> : IIntegrationEventHandler
    {
        public abstract Task HandleAsync(T message);

        public Task Invoke(string message)
        {
            // TODO temporary solution
#pragma warning disable CS0618 // Type or member is obsolete
            return HandleAsync(JsonConvert.DeserializeObject<T>(message, new JsonSerializerSettings { ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor, ContractResolver = new DefaultContractResolver { DefaultMembersSearchFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance } }));
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }
}
