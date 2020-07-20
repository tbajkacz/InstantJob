using System;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Rules;
using NUnit.Framework;

namespace InstantJob.Modules.Jobs.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class UpdateJobDetailsTests : BaseJobTest
    {
        private TestDelegate UpdateJobDetails => () => job.UpdateJobDetails("", "", 0, DateTime.UtcNow, Difficulty.Beginner, ownerMandator.Id);

        [Test]
        public void UpdateJobDetails_NotPossible_IfJobWasCanceled()
        {
            job.CancelJobOffer(ownerMandator.Id);
            AssertRuleWasBroken<JobWasNotCanceledRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);

            AssertRuleWasBroken<JobIsNotInProgressRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);
            job.AcceptJobAssignment(contractor.Id);
            job.CompleteJob(ownerMandator.Id);

            AssertRuleWasBroken<JobIsNotCompletedRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_NotPossible_IfContractorIsAssigned()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor, ownerMandator.Id);

            AssertRuleWasBroken<NoContractorAssignedRule>(UpdateJobDetails);
        }

        [Test]
        public void UpdateJobDetails_Succeeds_IfRulesNotViolated()
        {
            var (title, description, price, deadline, difficulty) =
                ("title", "desc", 11.12312M, DateTime.UtcNow, Difficulty.Intermediate);

            job.UpdateJobDetails(job.Title, job.Description, price, job.Deadline, job.Difficulty, ownerMandator.Id);
            job.ApplyForJob(contractor);

            job.UpdateJobDetails(title, description, job.Price, deadline, difficulty, ownerMandator.Id);

            Assert.AreEqual(job.Title, title);
            Assert.AreEqual(job.Description, description);
            Assert.AreEqual(job.Price, price);
            Assert.AreEqual(job.Deadline, deadline);
            Assert.AreEqual(job.Difficulty, difficulty);
        }
    }
}
