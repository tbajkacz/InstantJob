using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class AcceptJobAssignmentTests : BaseJobTest
    {
        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);

            job.CancelJobOffer();

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.AcceptJobAssignment());
        }

        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.AcceptJobAssignment());
        }

        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.AcceptJobAssignment());
        }

        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobHasNoAssignment()
        {
            job.ApplyForJob(contractor);

            AssertRuleWasBroken<JobMustHaveAssignmentRule>(() => job.AcceptJobAssignment());
        }

        [Test]
        public void AcceptJobAssignment_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            Assert.That(job.IsPerformedBy(contractor.Id));
            Assert.That(job.Status.IsInProgress);
        }
    }
}
