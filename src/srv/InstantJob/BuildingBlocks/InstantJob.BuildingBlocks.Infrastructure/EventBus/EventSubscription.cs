using System;

namespace InstantJob.BuildingBlocks.Infrastructure.EventBus
{
    internal class EventSubscription
    {
        public string Key { get; }

        public Type HandlerType { get; }

        public EventSubscription(string key, Type handlerType)
        {
            Key = key;
            HandlerType = handlerType;
        }
    }
}
