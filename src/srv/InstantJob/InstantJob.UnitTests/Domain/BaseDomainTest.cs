using InstantJob.Domain.Common;
using NUnit.Framework;

namespace InstantJob.UnitTests.Domain
{
    public abstract class BaseDomainTest
    {
        public static void AssertRuleWasBroken<TRule>(TestDelegate code) where TRule : IDomainRule
        {
            var exception = Assert.Catch<DomainException>(code);
            if (exception != null)
            {
                Assert.That(exception.Rule, Is.TypeOf<TRule>());
            }
        }
    }
}
