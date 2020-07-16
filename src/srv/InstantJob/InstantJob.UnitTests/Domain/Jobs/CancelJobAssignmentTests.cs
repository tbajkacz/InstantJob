using InstantJob.Domain.Jobs.Rules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantJob.UnitTests.Domain.Jobs
{
    [TestFixture]
    public class CancelJobAssignmentTests : BaseJobTest
    {
        [Test]
        public void CancelJobAssignment_NotPossible_IfJobWasCanceled()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.CancelJobOffer();

            AssertRuleWasBroken<JobWasNotCanceledRule>(() => job.CancelJobAssignment());
        }

        [Test]
        public void CancelJobAssignment_NotPossible_IfJobIsInProgress()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();

            AssertRuleWasBroken<JobIsNotInProgressRule>(() => job.CancelJobAssignment());
        }

        [Test]
        public void CancelJobAssignment_NotPossible_IfJobIsCompleted()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);
            job.AcceptJobAssignment();
            job.CompleteJob();

            AssertRuleWasBroken<JobIsNotCompletedRule>(() => job.CancelJobAssignment());
        }

        [Test]
        public void CancelJobAssignment_NotPossible_IfJobHasNoAssignment()
        {
            job.ApplyForJob(contractor);

            AssertRuleWasBroken<JobMustHaveAssignmentRule>(() => job.CancelJobAssignment());
        }

        [Test]
        public void CancelJobAssignment_Succeeds_IfRulesNotViolated()
        {
            job.ApplyForJob(contractor);
            job.AssignContractor(contractor);

            job.CancelJobAssignment();

            Assert.That(job.IsAssignedTo(contractor.Id), Is.Not.True);
            Assert.That(job.Status.IsAssigned, Is.Not.True);
        }
    }
}
