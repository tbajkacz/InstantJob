using System.Threading;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Exceptions;
using InstantJob.Modules.Jobs.Application.Interfaces;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.AssignContractor
{
    public class AssignContractorCommandHandler : IRequestHandler<AssignContractorCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly IContractorRepository contractorRepository;
        private readonly IMandatorRepository mandatorRepository;
        private readonly ICurrentMandatorService currentMandator;

        public AssignContractorCommandHandler(
            IJobRepository jobRepository,
            IContractorRepository contractorRepository,
            IMandatorRepository mandatorRepository,
            ICurrentMandatorService currentMandator)
        {
            this.jobRepository = jobRepository;
            this.contractorRepository = contractorRepository;
            this.mandatorRepository = mandatorRepository;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(AssignContractorCommand request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.JobId);

            var contractor = await contractorRepository.GetByIdAsync(request.ContractorId);
            var mandator =
                await mandatorRepository.GetByIdAsync(currentMandator.Id);

            job.AssignContractor(contractor, mandator.Id);
            await jobRepository.UpdateAsync(job);

            return Unit.Value;
        }
    }
}
