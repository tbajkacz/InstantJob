using InstantJob.BuildingBlocks.Domain;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain
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
