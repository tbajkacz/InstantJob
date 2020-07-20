using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CancelJobAssignmentTests : BaseJobTest
    {
        [Test]
        public void CancelJobAssignment_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.CancelJobOffer(ownerMandator.Id);

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.CancelJobAssignment(ownerMandator.Id));
        }

        [Test]
        public void CancelJobAssignment_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.CancelJobAssignment(ownerMandator.Id));
        }

        [Test]
        public void CancelJobAssignment_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.CancelJobAssignment(ownerMandator.Id));
        }

        [Test]
        public void CancelJobAssignment_NotPossible_IfJobHasNoAssignment()
        {
            job.ApplyForJob(contractor);

            AssertRuleWasBroken<JobMustHaveAssignmentRule>(() => job.CancelJobAssignment(ownerMandator.Id));
        }

        [Test]
        public void CancelJobAssignment_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);

            job.CancelJobAssignment(ownerMandator.Id);

            Assert.That(job.IsAssignedTo(contractor.Id), Is.Not.True);
            Assert.That(job.Status.IsAssigned, Is.Not.True);
        }
    }
}
