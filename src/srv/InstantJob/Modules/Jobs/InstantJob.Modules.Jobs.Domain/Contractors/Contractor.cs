using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.JobUsers;

namespace InstantJob.Modules.Jobs.Domain.Contractors
{
    public class Contractor : BaseEntity<Guid>
    {
        public virtual JobUser JobUser { get; protected set; }

        protected Contractor()
        {
        }

        public Contractor(Guid id, JobUser user)
        {
            Id = id;
            JobUser = user;
        }
    }
}
