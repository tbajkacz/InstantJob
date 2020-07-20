using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.ApplyForJob
{
    public class ApplyForJobCommandHandler : IRequestHandler<ApplyForJobCommand>
    {
        private readonly IJobRepository jobRepository;
        private readonly IContractorRepository contractorRepository;
        private readonly ICurrentContractorService currentContractor;

        public ApplyForJobCommandHandler(
            IJobRepository jobRepository,
            IContractorRepository contractorRepository,
            ICurrentContractorService currentContractor)
        {
            this.jobRepository = jobRepository;
            this.contractorRepository = contractorRepository;
            this.currentContractor = currentContractor;
        }

        public async Task<Unit> Handle(ApplyForJobCommand request, CancellationToken cancellationToken)
        {
            var contractor = await contractorRepository.GetByIdAsync(currentContractor.Id);
            var job = await jobRepository.GetByIdAsync(request.JobId);

            job.ApplyForJob(contractor);

            await jobRepository.UpdateAsync(job);
            return Unit.Value;
        }
    }
}
