using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class AssignContractorTests : BaseJobTest
    {
        [Test]
        public void AssignContractor_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.CancelJobOffer();

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.AssignContractor(contractor));
        }

        [Test]
        public void AssignContractor_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.AssignContractor(contractor));
        }

        [Test]
        public void AssignContractor_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.AssignContractor(contractor));
        }

        [Test]
        public void AssignContractor_NotPossible_IfContractorHasNotApplied()
        {
            AssertRuleWasBroken<ContractorMustHaveActiveApplicationRule>(() => job.AssignContractor(contractor));
        }

        [Test]
        public void AssignContractor_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);

            Assert.That(job.IsAssignedTo(contractor.Id));
        }
    }
}
