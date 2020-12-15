using System.Collections.Generic;

namespace InstantJob.BuildingBlocks.Domain
{
    public abstract class BaseEntity<TId> : BaseEntity
    {
        public virtual TId Id { get; set; }
    }

    public abstract class BaseEntity
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

        protected virtual void CheckRule(IDomainRule rule)
        {
            if (rule.IsViolated())
            {
                throw new DomainException(rule);
            }
        }
    }
}