using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.AssignContractor
{
    public class AssignContractorCommandHandler : IRequestHandler<AssignContractorCommand>
    {
        private readonly IJobRepository jobs;
        private readonly IContractorRepository contractors;
        private readonly IMandatorRepository mandators;
        private readonly ICurrentMandatorService currentMandator;

        public AssignContractorCommandHandler(
            IJobRepository jobs,
            IContractorRepository contractors,
            IMandatorRepository mandators,
            ICurrentMandatorService currentMandator)
        {
            this.jobs = jobs;
            this.contractors = contractors;
            this.mandators = mandators;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(AssignContractorCommand request, CancellationToken cancellationToken)
        {
            var job = await jobs.GetByIdAsync(request.JobId);

            var contractor = await contractors.GetByIdAsync(request.ContractorId);
            var mandator =
                await mandators.GetByIdAsync(currentMandator.Id);

            job.AssignContractor(contractor, mandator.Id);
            await jobs.UpdateAsync(job);

            return Unit.Value;
        }
    }
}
