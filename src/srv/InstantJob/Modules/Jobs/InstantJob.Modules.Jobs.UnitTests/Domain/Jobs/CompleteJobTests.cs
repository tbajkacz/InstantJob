using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CompleteJobTests : BaseJobTest
    {
        [Test]
        public void CompleteJob_NotPossible_IfJobIsNotInProgress()
        {
            AssertRuleWasBroken<JobIsInProgressRule>(() => job.CompleteJob(ownerMandator.Id));

            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);

            AssertRuleWasBroken<JobIsInProgressRule>(() => job.CompleteJob(ownerMandator.Id));
        }

        [Test]
        public void CompleteJob_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            Assert.That(job.CompletionInfo, Is.Not.EqualTo(null));
            Assert.That(job.Status.IsCompleted);
        }
    }
}
