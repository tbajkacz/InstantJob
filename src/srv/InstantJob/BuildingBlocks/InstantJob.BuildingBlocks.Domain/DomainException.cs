using System;

namespace InstantJob.BuildingBlocks.Domain
{
    public class DomainException : Exception
    {
        public IDomainRule Rule { get; set; }

        public DomainException(IDomainRule rule)
            : base(rule.Message)
        {
            Rule = rule;
        }
    }
}
