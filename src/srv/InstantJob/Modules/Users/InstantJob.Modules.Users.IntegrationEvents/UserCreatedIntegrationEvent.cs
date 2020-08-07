using System;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Users.IntegrationEvents
{
    public class UserCreatedIntegrationEvent : IIntegrationEvent
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Role Role { get; set; }

        public UserCreatedIntegrationEvent(Guid userId, string name, string surname, string email, Role role)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
            Role = role;
        }
    }
}
