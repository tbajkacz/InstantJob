using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.Users.Events;

namespace InstantJob.Modules.Users.Domain.Users
{
    public class User : BaseEntity<int>
    {
        public virtual string Name { get; protected set; }

        public virtual string Surname { get; protected set; }

        public virtual int? Age { get; protected set; }

        public virtual string PasswordHash { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual string Picture { get; protected set; }

        public virtual Role Role { get; protected set; }

        protected User()
        {
        }

        public User(int userRegistrationId, string name, string surname, string passwordHash,
            string email, Role role)
        {
            Id = userRegistrationId;
            Name = name;
            Surname = surname;
            PasswordHash = passwordHash;
            Email = email;
            Role = role;

            this.AddDomainEvent(new UserCreatedDomainEvent(Id, Name, Surname, Email, Role));
        }

        public virtual void UpdateInformation(string name, string surname, int? age, string picture)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Picture = picture;
        }

        public virtual void UpdatePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        //TODO when deleting a user publish the id in order to delete the jobs he created
        //if he was in progress with some jobs then take action as well
    }
}
