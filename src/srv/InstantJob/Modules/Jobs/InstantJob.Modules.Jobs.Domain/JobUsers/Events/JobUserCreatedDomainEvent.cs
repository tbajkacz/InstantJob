using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.JobUsers.Events
{
    public class JobUserCreatedDomainEvent : IDomainEvent
    {
        public JobUser JobUser { get; set; }

        public JobUserCreatedDomainEvent(JobUser jobUser)
        {
            JobUser = jobUser;
        }
    }
}
