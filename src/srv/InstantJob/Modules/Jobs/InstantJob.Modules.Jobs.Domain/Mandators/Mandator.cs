using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Mandators
{
    public class Mandator : BaseEntity<int>
    {
        public virtual int UserId { get; protected set; }

        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string Email { get; protected set; }

        protected Mandator()
        {
        }

        public Mandator(int userId, string name, string surname, string email)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
