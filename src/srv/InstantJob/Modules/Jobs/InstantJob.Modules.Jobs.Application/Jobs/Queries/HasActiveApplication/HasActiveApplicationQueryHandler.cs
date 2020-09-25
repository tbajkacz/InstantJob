using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.HasActiveApplication
{
    public class HasActiveApplicationQueryHandler : IRequestHandler<HasActiveApplicationQuery, HasActiveApplicationDto>
    {
        private readonly IJobRepository jobs;
        private readonly ICurrentContractorService currentContractor;

        public HasActiveApplicationQueryHandler(
            IJobRepository jobs,
            ICurrentContractorService currentContractor)
        {
            this.jobs = jobs;
            this.currentContractor = currentContractor;
        }

        public async Task<HasActiveApplicationDto> Handle(HasActiveApplicationQuery request, CancellationToken cancellationToken)
        {
            var job = await jobs.GetByIdAsync(request.JobId);

            return new HasActiveApplicationDto { HasActiveApplication = job.HasActiveApplication(currentContractor.Id) };
        }
    }
}
