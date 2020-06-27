using InstantJob.Core.Common.Exceptions;
using InstantJob.Core.Common.Interfaces;

namespace InstantJob.Core.Common.Types
{
    public abstract class BaseEntity<TId>
    {
        public virtual TId Id { get; set; }

        protected void CheckRule(IDomainRule rule)
        {
            if (rule.IsFailed())
            {
                throw new DomainException(rule);
            }
        }
    }
}