using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CancelJobOfferTests : BaseJobTest
    {
        [Test]
        public void CancelJobOffer_NotPossible_IfJobWasCanceled()
        {
            job.CancelJobOffer(ownerMandator.Id);

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.CancelJobOffer(ownerMandator.Id));
        }

        [Test]
        public void CancelJobOffer_Notpossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.CancelJobOffer(ownerMandator.Id));
        }

        [Test]
        public void CancelJobOffer_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.CancelJobOffer(ownerMandator.Id));
        }

        [Test]
        public void CancelJobOffer_Succeeds_IfRulesNotViolated()
        {
            job.CancelJobOffer(ownerMandator.Id);

            Assert.That(job.Status.IsCanceled);
        }

        [Test]
        public void CancelJobOffer_Succeeds_IfRulesNotViolatedAndContractorAssigned()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);

            job.CancelJobOffer(ownerMandator.Id);

            Assert.That(job.Status.IsCanceled);
        }
    }
}
