using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class AssignContractorTests : BaseJobTest
    {
        [Test]
        public void AssignContractor_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.CancelJobOffer(ownerMandator.Id);

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.AssignContractor(contractor, ownerMandator.Id));
        }

        [Test]
        public void AssignContractor_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.AssignContractor(contractor, ownerMandator.Id));
        }

        [Test]
        public void AssignContractor_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.AssignContractor(contractor, ownerMandator.Id));
        }

        [Test]
        public void AssignContractor_NotPossible_IfContractorHasNotApplied()
        {
            AssertRuleWasBroken<ContractorMustHaveActiveApplicationRule>(() => job.AssignContractor(contractor, ownerMandator.Id));
        }

        [Test]
        public void AssignContractor_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);

            Assert.That(job.IsAssignedTo(contractor.Id));
            Assert.That(job.Status.IsAssigned);
        }
    }
}
