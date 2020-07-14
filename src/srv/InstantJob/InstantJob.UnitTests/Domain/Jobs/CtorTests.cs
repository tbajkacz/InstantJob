using InstantJob.Domain.Categories.Entities;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Jobs.Rules;
using InstantJob.Domain.Users.Constants;
using InstantJob.Domain.Users.Entities;
using NUnit.Framework;
using System;
using System.Linq;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CtorTests : BaseDomainTest
    {
        private Action<User> jobCtor = u =>
            new Job("",
                "",
                0,
                DateTime.UtcNow,
                Difficulty.Beginner,
                new Category("", ""),
                u);

        [Test]
        public void Ctor_Fails_IfUserIsNotMandator()
        {
            var user = new User();

            foreach (var role in Roles.RolesCollection.Where(r => r != Roles.Mandator))
            {
                user.Roles.Add(role);
            }
            AssertRuleWasBroken<MustBeMandatorRule>(() => jobCtor(user));
        }

        [Test]
        public void Ctor_Succeeds_IfUserIsMandator()
        {
            var user = new User();
            user.Roles.Add(Roles.Mandator);

            Assert.DoesNotThrow(() => jobCtor(user));
        }
    }
}
