using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Domain.Users.Events
{
    public class UserCreatedDomainEvent : IDomainEvent
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public UserCreatedDomainEvent(int userId, string name, string surname,
            string email, Role role)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
        }
    }
}
