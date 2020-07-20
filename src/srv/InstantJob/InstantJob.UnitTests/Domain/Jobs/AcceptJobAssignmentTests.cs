using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class AcceptJobAssignmentTests : BaseJobTest
    {
        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);

            job.CancelJobOffer(ownerMandator.Id);

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.AcceptJobAssignment(contractor.Id));
        }

        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.AcceptJobAssignment(contractor.Id));
        }

        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.AcceptJobAssignment(contractor.Id));
        }

        [Test]
        public void AcceptJobAssignment_NotPossible_IfJobHasNoAssignment()
        {
            job.ApplyForJob(contractor);

            AssertRuleWasBroken<JobMustHaveAssignmentRule>(() => job.AcceptJobAssignment(contractor.Id));
        }

        [Test]
        public void AcceptJobAssignment_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            Assert.That(job.IsPerformedBy(contractor.Id));
            Assert.That(job.Status.IsInProgress);
        }
    }
}
