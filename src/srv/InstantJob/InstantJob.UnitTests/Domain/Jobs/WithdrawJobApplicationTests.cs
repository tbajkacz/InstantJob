using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class WithdrawJobApplicationTests : BaseJobTest
    {
        [Test]
        public void WithdrawJobApplication_NotPossible_IfNoActiveApplication()
        {
            AssertRuleWasBroken<ContractorMustHaveActiveApplicationRule>(() => job.WithdrawJobApplication(contractor));
        }

        [Test]
        public void WithdrawJobApplication_NotPossible_IfContractorInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<ContractorMustNotBePerformingJobRule>(() => job.WithdrawJobApplication(contractor));
        }

        [Test]
        public void WithdrawJobApplication_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.WithdrawJobApplication(contractor));
        }

        [Test]
        public void WithdrawJobApplication_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.CancelJobOffer();

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.WithdrawJobApplication(contractor));
        }

        [Test]
        public void WithdrawJobApplication_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.WithdrawJobApplication(contractor);

            Assert.That(job.HasActiveApplication(contractor.Id), Is.Not.True);
        }
    }
}
