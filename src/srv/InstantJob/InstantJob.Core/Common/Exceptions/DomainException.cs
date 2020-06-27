using InstantJob.Core.Common.Interfaces;
using System;

namespace InstantJob.Core.Common.Exceptions
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
