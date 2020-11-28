using System;

namespace InstantJob.BuildingBlocks.Application.EventBus
{
    public interface IIntegrationEvent
    {
        static string GetKey() => throw new NotImplementedException();
    }
}
