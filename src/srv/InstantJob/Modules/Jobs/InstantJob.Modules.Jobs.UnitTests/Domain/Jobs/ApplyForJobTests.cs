using System.Collections.Generic;
using System.Linq;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using InstantJob.Modules.Jobs.Domain.Mandators;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class ApplyForJobTests : BaseJobTest
    {
        private Mandator mandator;
        private Contractor contractor2;

        [SetUp]
        public void SetupApplyForJob()
        {
            mandator = new Mandator("", "", "");
            contractor2 = new Contractor("", "", "");

            mandator.Id = NextId();
            contractor2.Id = NextId();
        }

        [Test]
        public void ApplyForJob_NotPossible_IfJobWasCanceled()
        {
            job.CancelJobOffer(ownerMandator.Id);

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_NotPossible_IfContractorAlreadyApplied()
        {
            job.ApplyForJob(contractor);

            AssertRuleWasBroken<ContractorMustNotHaveTwoActiveApplicationsRule>(() => job.ApplyForJob(contractor));
        }

        [Test]
        public void ApplyForJob_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.ApplyForJob(contractor2);

            Assert.That(job.HasActiveApplication(contractor.Id));
            Assert.That(job.HasActiveApplication(contractor2.Id));

            job.WithdrawJobApplication(contractor.Id);

            job.ApplyForJob(contractor);

            Assert.That(job.HasActiveApplication(contractor.Id));
            Assert.That(job.Applications.Count(), Is.EqualTo(3));
        }
    }
}
