using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.Internal;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.BuildingBlocks.Infrastructure.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InstantJob.BuildingBlocks.Infrastructure.EventBus
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly IServiceProvider provider;

        public InMemoryEventBus(IServiceProvider provider, EventSubscriptionOptions options)
        {
            this.provider = provider;
            subscriptions = options.Subscriptions;
        }


        private readonly List<EventSubscription> subscriptions = new List<EventSubscription>();

        public async Task PublishAsync(string key, string message)
        {
            using var scope = provider.CreateScope();
            using var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var dispatcher = scope.ServiceProvider.GetRequiredService<IDomainEventsDispatcher>();

            if (!uow.Active)
            {
                uow.BeginTransaction();
            }

            foreach (var sub in subscriptions.Where(s => s.Key == key))
            {
                await ((IIntegrationEventHandler)scope.ServiceProvider.GetRequiredService(sub.HandlerType)).InvokeAsync(message);
            }

            await dispatcher.DispatchDomainEventsAsync();

            if (uow.Active)
            {
                await uow.CommitAsync();
            }
        }

        public void Subscribe<THandler>(string key) where THandler : IIntegrationEventHandler
        {
            var eventSubscription = new EventSubscription(key, typeof(THandler));

            subscriptions.Add(eventSubscription);
        }
    }
}
