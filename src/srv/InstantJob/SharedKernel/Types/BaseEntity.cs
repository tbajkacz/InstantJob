using System.Collections.Generic;

namespace SharedKernel.Types
{
    public abstract class BaseEntity<TId>
    {
        public virtual TId Id { get; set; }

        public virtual List<BaseDomainEvent> Events { get; set; } = new List<BaseDomainEvent>();
    }
}