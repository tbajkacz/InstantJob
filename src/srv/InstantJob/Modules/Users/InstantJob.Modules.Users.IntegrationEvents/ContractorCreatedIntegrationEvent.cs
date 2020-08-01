using InstantJob.BuildingBlocks.Application.EventBus;

namespace InstantJob.Modules.Users.IntegrationEvents
{
    public class ContractorCreatedIntegrationEvent : IIntegrationEvent
    {
        public int UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public ContractorCreatedIntegrationEvent(int userId, string name, string surname, string email)
        {
            UserId = userId;
            Name = name;
            Surname = surname;
            Email = email;
        }
    }
}
