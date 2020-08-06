using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Categories;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using InstantJob.Modules.Jobs.Domain.Mandators;
using InstantJob.Modules.Jobs.Domain.Users;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    public abstract class BaseJobTest : BaseDomainTest
    {
        private static int currentId = 0;

        protected static int NextId() => ++currentId;

        protected Job job;

        protected Mandator ownerMandator;
        protected Contractor contractor;

        [SetUp]
        public void Setup()
        {
            currentId = 0;

            var ownerMandatorId = NextId();
            var contractorId = NextId();

            ownerMandator = new Mandator(ownerMandatorId, new JobUser(ownerMandatorId, "", "", "", Role.Mandator));
            contractor = new Contractor(contractorId, new JobUser(contractorId, "", "", "", Role.Mandator));

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
