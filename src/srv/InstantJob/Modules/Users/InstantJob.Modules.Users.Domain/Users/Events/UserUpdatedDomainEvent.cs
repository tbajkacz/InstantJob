using System;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.Domain.Users.Events
{
    public class UserUpdatedDomainEvent : IDomainEvent
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Age { get; set; }

        public string Picture { get; set; }

        public Role Role { get; set; }

        public UserUpdatedDomainEvent(Guid userId, string name, string surname, int? age, string picture, Role role)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Age = age;
            Picture = picture;
            Role = role;
        }
    }
}
