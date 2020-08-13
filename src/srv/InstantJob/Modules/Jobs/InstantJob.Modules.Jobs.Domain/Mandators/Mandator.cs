using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.JobUsers;

namespace InstantJob.Modules.Jobs.Domain.Mandators
{
    public class Mandator : BaseEntity<Guid>
    {
        public virtual JobUser JobUser { get; protected set; }

        protected Mandator()
        {
        }

        public Mandator(Guid id, JobUser user)
        {
            Id = id;
            JobUser = user;
        }
    }
}
