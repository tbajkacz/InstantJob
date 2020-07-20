namespace InstantJob.BuildingBlocks.Domain
{
    public abstract class BaseEntity<TId>
    {
        public virtual TId Id { get; set; }

        protected void CheckRule(IDomainRule rule)
        {
            if (rule.IsViolated())
            {
                throw new DomainException(rule);
            }
        }
    }
}