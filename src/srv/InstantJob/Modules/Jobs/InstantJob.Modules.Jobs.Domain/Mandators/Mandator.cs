using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Users;

namespace InstantJob.Modules.Jobs.Domain.Mandators
{
    public class Mandator : BaseEntity<int>
    {
        public virtual JobUser JobUser { get; protected set; }

        protected Mandator()
        {
        }

        public Mandator(int id, JobUser user)
        {
            Id = id;
            JobUser = user;
        }
    }
}
