using InstantJob.Domain.Categories.Entities;
using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Entities;
using InstantJob.Domain.Users.Constants;
using InstantJob.Domain.Users.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace InstantJob.UnitTests.Domain.Jobs
{
    public abstract class BaseJobTest : BaseDomainTest
    {
        private static int currentId = 0;

        protected static int NextId() => ++currentId;

        protected Job job;

        protected User ownerMandator = new User() { Id = NextId(), Roles = new List<string> { Roles.Mandator, Roles.Contractor } };
        protected User contractor = new User() { Id = NextId(), Roles = new List<string> { Roles.Contractor } };

        [SetUp]
        public void Setup()
        {
            currentId = 0;

            job = new Job(
                "",
                "",
                0,
                DateTime.UtcNow,
                Difficulty.Beginner,
                new Category("", ""),
                ownerMandator);
        }

        [TearDown]
        public void Teardown()
        {
            job = null;
        }
    }
}
