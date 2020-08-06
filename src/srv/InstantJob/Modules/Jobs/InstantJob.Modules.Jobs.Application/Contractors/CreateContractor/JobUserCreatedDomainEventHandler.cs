using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Contractors;
using InstantJob.Modules.Jobs.Domain.Users.Events;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Contractors.CreateContractor
{
    public class JobUserCreatedDomainEventHandler : INotificationHandler<JobUserCreatedDomainEvent>
    {
        private readonly IContractorRepository contractors;

        public JobUserCreatedDomainEventHandler(IContractorRepository contractors)
        {
            this.contractors = contractors;
        }

        public async Task Handle(JobUserCreatedDomainEvent notification,
            CancellationToken cancellationToken)
        {
            if (notification.JobUser.Role != Role.Contractor)
            {
                return;
            }

            var contractor = new Contractor(notification.JobUser.Id, notification.JobUser);

            await contractors.AddAsync(contractor);
        }
    }
}
