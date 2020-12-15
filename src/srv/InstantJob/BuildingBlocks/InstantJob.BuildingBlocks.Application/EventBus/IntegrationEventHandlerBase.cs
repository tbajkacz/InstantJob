using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;
using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEventHandler
    {
        Task InvokeAsync(string message);
    }

    public abstract class IntegrationEventHandlerBase<T> : IIntegrationEventHandler
    {
        private readonly JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
#pragma warning disable CS0618 // Type or member is obsolete
            ContractResolver = new DefaultContractResolver { DefaultMembersSearchFlags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance }
#pragma warning restore CS0618 // Type or member is obsolete
        };

        public abstract Task HandleAsync(T message);

        public Task InvokeAsync(string message)
        {
            // TODO temporary solution

            return HandleAsync(JsonConvert.DeserializeObject<T>(message, jsonSerializerSettings));
        }
    }
}
