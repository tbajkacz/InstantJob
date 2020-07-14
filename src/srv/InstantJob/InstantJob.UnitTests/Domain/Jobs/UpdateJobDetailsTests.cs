using InstantJob.Domain.Jobs.Constants;
using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;
using System;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class UpdateJobDetailsTests : BaseJobTest
    {
        private TestDelegate UpdateJobDetails => () => job.UpdateJobDetails("", "", 0, DateTime.UtcNow, Difficulty.Beginner);

        [Test]
        public void UpdateJobDetails_NotPossible_IfJobWasCanceled()
        {
            job.CancelJobOffer();
            AssertRuleWasBroken<JobWasNotCanceledRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<JobIsNotInProgressRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_NotPossible_IfContractorIsAssigned()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);

            AssertRuleWasBroken<NoContractorAssignedRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_Succeeds_IfRulesNotViolated()
        {
            var (title, description, price, deadline, difficulty) =
                ("title", "desc", 11.12312M, DateTime.UtcNow, Difficulty.Intermediate);

            job.UpdateJobDetails(job.Title, job.Description, price, job.Deadline, job.Difficulty);
            job.ApplyForJob(contractor);

            job.UpdateJobDetails(title, description, job.Price, deadline, difficulty);

            Assert.AreEqual(job.Title, title);
            Assert.AreEqual(job.Description, description);
            Assert.AreEqual(job.Price, price);
            Assert.AreEqual(job.Deadline, deadline);
            Assert.AreEqual(job.Difficulty, difficulty);
        }
    }
}
