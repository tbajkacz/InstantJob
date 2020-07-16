using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CancelJobOfferTests : BaseJobTest
    {
        [Test]
        public void CancelJobOffer_NotPossible_IfJobWasCanceled()
        {
            job.CancelJobOffer();

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.CancelJobOffer());
        }

        [Test]
        public void CancelJobOffer_Notpossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.CancelJobOffer());
        }

        [Test]
        public void CancelJobOffer_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.CancelJobOffer());
        }

        [Test]
        public void CancelJobOffer_Succeeds_IfRulesNotViolated()
        {
            job.CancelJobOffer();

            Assert.That(job.Status.IsCanceled);
        }

        [Test]
        public void CancelJobOffer_Succeeds_IfRulesNotViolatedAndContractorAssigned()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);

            job.CancelJobOffer();

            Assert.That(job.Status.IsCanceled);
        }
    }
}
