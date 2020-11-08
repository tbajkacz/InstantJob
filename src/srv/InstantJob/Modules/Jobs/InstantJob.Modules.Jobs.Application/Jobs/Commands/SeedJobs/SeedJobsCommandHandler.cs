using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.SeedJobs
{
    public class SeedJobsCommandHandler : IRequestHandler<SeedJobsCommand>
    {
        private readonly IJobRepository jobRepository;

        public SeedJobsCommandHandler(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public async Task<Unit> Handle(SeedJobsCommand request, CancellationToken cancellationToken)
        {
            if (jobRepository.Get().Any())
            {
                return Unit.Value;
            }

            // TODO AddRange
            foreach (var job in request.Jobs)
            {
                await jobRepository.AddAsync(job);
            }

            return Unit.Value;
        }
    }
}
