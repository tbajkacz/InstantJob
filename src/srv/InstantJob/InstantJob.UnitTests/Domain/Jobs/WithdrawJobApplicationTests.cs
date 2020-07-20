using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class WithdrawJobApplicationTests : BaseJobTest
    {
        [Test]
        public void WithdrawJobApplication_NotPossible_IfNoActiveApplication()
        {
            AssertRuleWasBroken<ContractorMustHaveActiveApplicationRule>(() => job.WithdrawJobApplication(contractor.Id));
        }

        [Test]
        public void WithdrawJobApplication_NotPossible_IfContractorInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<ContractorMustNotBePerformingJobRule>(() => job.WithdrawJobApplication(contractor.Id));
        }

        [Test]
        public void WithdrawJobApplication_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.WithdrawJobApplication(contractor.Id));
        }

        [Test]
        public void WithdrawJobApplication_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.CancelJobOffer(ownerMandator.Id);

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.WithdrawJobApplication(contractor.Id));
        }

        [Test]
        public void WithdrawJobApplication_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.WithdrawJobApplication(contractor.Id);

            Assert.That(job.HasActiveApplication(contractor.Id), Is.Not.True);
        }
    }
}
