
namespace InstantJob.Domain.Common
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