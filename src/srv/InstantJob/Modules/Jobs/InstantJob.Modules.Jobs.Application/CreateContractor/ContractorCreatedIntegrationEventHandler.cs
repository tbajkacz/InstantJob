using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.EventBus;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Users.IntegrationEvents;

namespace InstantJob.Modules.Jobs.Application.CreateContractor
{
    public class ContractorCreatedIntegrationEventHandler : IIntegrationEventHandler<ContractorCreatedIntegrationEvent>
    {
        private readonly IContractorRepository contractors;

        public ContractorCreatedIntegrationEventHandler(IContractorRepository contractors)
        {
            this.contractors = contractors;
        }

        public async Task Handle(ContractorCreatedIntegrationEvent notification,
            CancellationToken cancellationToken)
        {
            var contractor = new Contractor(notification.UserId, notification.Name, notification.Surname, notification.Email);

            await contractors.AddAsync(contractor);
        }
    }
}
