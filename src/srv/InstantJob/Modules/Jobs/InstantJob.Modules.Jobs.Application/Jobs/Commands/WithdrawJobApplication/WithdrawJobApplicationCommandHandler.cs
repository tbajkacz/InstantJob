using System.Threading;
using System.Threading.Tasks;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.WithdrawJobApplication
{
    public class WithdrawJobApplicationCommandHandler : IRequestHandler<WithdrawJobApplicationCommand>
    {
        private readonly IJobRepository jobs;
        private readonly ICurrentContractorService currentContractor;

        public WithdrawJobApplicationCommandHandler(IJobRepository jobs, ICurrentContractorService currentContractor)
        {
            this.jobs = jobs;
            this.currentContractor = currentContractor;
        }

        public async Task<Unit> Handle(WithdrawJobApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var job = await jobs.GetByIdAsync(request.JobId);

            job.WithdrawJobApplication(currentContractor.Id);

            await jobs.UpdateAsync(job);

            return Unit.Value;;
        }
    }
}
