using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Application.Mandators.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.CancelJobAssignment
{
    public class CancelJobAssignmentCommandHandler : IRequestHandler<CancelJobAssignmentCommand>
    {
        private readonly IJobRepository jobs;
        private readonly ICurrentMandatorService currentMandator;

        public CancelJobAssignmentCommandHandler(IJobRepository jobs, ICurrentMandatorService currentMandator)
        {
            this.jobs = jobs;
            this.currentMandator = currentMandator;
        }

        public async Task<Unit> Handle(CancelJobAssignmentCommand request, CancellationToken cancellationToken)
        {
            var job = await jobs.GetByIdAsync(request.JobId);

            job.CancelJobAssignment(currentMandator.Id);

            return Unit.Value;
        }
    }
}
