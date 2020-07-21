using System.Collections.Generic;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.DomainEvents
{
    public interface IDomainEventsAccessor
    {
        IEnumerable<INotification> PopUnhandledDomainEvents();
    }
}
