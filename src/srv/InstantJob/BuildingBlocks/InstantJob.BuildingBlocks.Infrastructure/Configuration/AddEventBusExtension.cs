using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.BuildingBlocks.Infrastructure.EventBus;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace InstantJob.BuildingBlocks.Infrastructure.Configuration
{
    public static class AddEventBusExtension
    {
        public static IEventBusBuilder AddInMemoryEventBus(this IServiceCollection services)
        {
            services.AddSingleton<IEventBus, InMemoryEventBus>();
            return new EventBusBuilder(services);
        }
    }

    public interface IEventBusBuilder
    {
        IServiceCollection RegisterIntegrationEventHandlers(Action<EventSubscriptionOptions> action);
    }

    internal class EventBusBuilder : IEventBusBuilder
    {
        private readonly IServiceCollection services;

        public EventBusBuilder(IServiceCollection services)
        {
            this.services = services;
        }

        public IServiceCollection RegisterIntegrationEventHandlers(Action<EventSubscriptionOptions> action)
        {
            var subscriptionOptions = new EventSubscriptionOptions();

            action?.Invoke(subscriptionOptions);

            subscriptionOptions.Subscriptions.ForEach(s => services.AddTransient(s.HandlerType));

            return services.AddSingleton(subscriptionOptions);
        }
    }

    public class EventSubscriptionOptions
    {
        internal List<EventSubscription> Subscriptions { get; } = new List<EventSubscription>();

        public void AddHandler<T>(string key) where T : IIntegrationEventHandler
        {
            Subscriptions.Add(new EventSubscription(key, typeof(T)));
        }
    }
}
