using System.Collections.Generic;
using MediatR;

namespace InstantJob.BuildingBlocks.Domain
{
    public abstract class BaseDomainEntity
    {
        private readonly IList<IDomainEvent> domainEvents = new List<IDomainEvent>();

        public virtual IEnumerable<IDomainEvent> DomainEvents => domainEvents;

        public virtual void AddDomainEvent(IDomainEvent @event)
        {
            domainEvents.Add(@event);
        }

        public virtual void ClearDomainEvents()
        {
            domainEvents.Clear();
        }
    }
}
