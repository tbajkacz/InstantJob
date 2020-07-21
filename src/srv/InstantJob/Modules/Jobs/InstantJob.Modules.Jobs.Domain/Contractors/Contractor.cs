using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Contractors
{
    public class Contractor : BaseEntity<int>
    {
        public virtual int UserId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual int? Age { get; protected set; }

        public virtual string Email { get; protected set; }
    }
}
