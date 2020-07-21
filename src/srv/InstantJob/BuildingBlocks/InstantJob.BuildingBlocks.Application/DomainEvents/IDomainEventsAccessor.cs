using System.Collections.Generic;
using InstantJob.BuildingBlocks.Domain;
using MediatR;

namespace InstantJob.BuildingBlocks.Application.DomainEvents
{
    public interface IDomainEventsAccessor
    {
        IEnumerable<IDomainEvent> PopUnhandledDomainEvents();
    }
}
