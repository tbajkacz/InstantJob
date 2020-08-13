using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.ApplyForJob
{
    public class ApplyForJobCommandHandler : IRequestHandler<ApplyForJobCommand>
    {
        private readonly IJobRepository jobs;
        private readonly IContractorRepository contractors;
        private readonly ICurrentContractorService currentContractor;

        public ApplyForJobCommandHandler(
            IJobRepository jobs,
            IContractorRepository contractors,
            ICurrentContractorService currentContractor)
        {
            this.jobs = jobs;
            this.contractors = contractors;
            this.currentContractor = currentContractor;
        }

        public async Task<Unit> Handle(ApplyForJobCommand request, CancellationToken cancellationToken)
        {
            var contractor = await contractors.GetByIdAsync(currentContractor.Id);
            var job = await jobs.GetByIdAsync(request.JobId);

            job.ApplyForJob(contractor);

            await jobs.UpdateAsync(job);
            return Unit.Value;
        }
    }
}
