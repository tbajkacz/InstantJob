using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Users;

namespace InstantJob.Modules.Jobs.Domain.Contractors
{
    public class Contractor : BaseEntity<int>
    {
        public virtual JobUser JobUser { get; protected set; }

        protected Contractor()
        {
        }

        public Contractor(int id, JobUser user)
        {
            Id = id;
            JobUser = user;
        }
    }
}
