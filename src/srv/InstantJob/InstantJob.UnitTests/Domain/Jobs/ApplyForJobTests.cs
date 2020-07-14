﻿using InstantJob.Domain.Jobs.Rules;
using InstantJob.Domain.Users.Constants;
using InstantJob.Domain.Users.Entities;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class ApplyForJobTests : BaseJobTest
    {
        private User mandator = new User() { Id = NextId(), Roles = new List<string> { Roles.Mandator, Roles.Administrator } };
        private User contractor2 = new User() { Id = NextId(), Roles = new List<string> { Roles.Contractor } };

        [Test]
        public void ApplyForJob_NotPossible_IfJobWasCanceled()
        {
            job.CancelJobOffer();

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfContractorAlreadyApplied()
        {
            job.ApplyForJob(contractor);

            AssertRuleWasBroken<ContractorCannotApplyTwiceRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfNotContractorApplies()
        {
            AssertRuleWasBroken<MustBeContractorRule>(() => job.ApplyForJob(mandator));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfOwnerApplies()
        {
            AssertRuleWasBroken<MandatorCannotApplyToHisJobRule>(() => job.ApplyForJob(ownerMandator));
        }

        [Test]
        public void ApplyForJob_Succeeds_IfRulesNotViolated()
        {
            Assert.DoesNotThrow(() => job.ApplyForJob(contractor));
            Assert.DoesNotThrow(() => job.ApplyForJob(contractor2));

            Assert.That(job.Applications.Any(a => a.Contractor.Id == contractor.Id));
            Assert.That(job.Applications.Any(a => a.Contractor.Id == contractor2.Id));
        }
    }
}