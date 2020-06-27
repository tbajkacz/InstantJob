using System;

namespace InstantJob.Domain.Common
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
