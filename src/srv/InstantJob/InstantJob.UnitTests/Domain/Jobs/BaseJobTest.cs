using System;
using System.Collections.Generic;
using InstantJob.Modules.Jobs.Domain.Categories;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using InstantJob.Modules.Jobs.Domain.Mandators;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    public abstract class BaseJobTest : BaseDomainTest
    {
        private static int currentId = 0;

        protected static int NextId() => ++currentId;

        protected Job job;

        protected Mandator ownerMandator = new Mandator() { Id = NextId() };
        protected Contractor contractor = new Contractor() { Id = NextId() };

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
