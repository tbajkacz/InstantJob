using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CompleteJobTests : BaseJobTest
    {
        [Test]
        public void CompleteJob_NotPossible_IfJobIsNotInProgress()
        {
            AssertRuleWasBroken<JobIsInProgressRule>(() => job.CompleteJob());

            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);

            AssertRuleWasBroken<JobIsInProgressRule>(() => job.CompleteJob());
        }

        [Test]
        public void CompleteJob_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            Assert.That(job.CompletionInfo, Is.Not.EqualTo(null));
        }
    }
}
