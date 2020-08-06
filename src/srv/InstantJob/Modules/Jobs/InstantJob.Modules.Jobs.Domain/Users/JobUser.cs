using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Domain.Users.Events;

namespace InstantJob.Modules.Jobs.Domain.Users
{
    public class JobUser : BaseEntity<int>
    {
        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual Role Role { get; protected set; }

        protected JobUser()
        {
        }

        public JobUser(int id, string name, string surname, string email, Role role)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;

            this.AddDomainEvent(new JobUserCreatedDomainEvent(this));
        }

        public virtual void UpdateInformation(string name, string surname)
        {
            Name = name;
            Surname = surname;
        }
    }
}
