using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Contractors
{
    public class Contractor : BaseEntity<int>
    {
        public virtual int UserId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string Email { get; protected set; }

        protected Contractor()
        {
        }

        public Contractor(int userId, string name, string surname, string email)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
