using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetContractorStatistics
{
    public class GetContractorStatisticsQueryHandler : IRequestHandler<GetContractorStatisticsQuery, GetContractorStatisticsDto>
    {
        private readonly IJobRepository jobRepository;

        public GetContractorStatisticsQueryHandler(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public Task<GetContractorStatisticsDto> Handle(GetContractorStatisticsQuery request, CancellationToken cancellationToken)
        {
            if (request.ContractorId == null)
            {
                return Task.FromResult(new GetContractorStatisticsDto());
            }

            var contractorJobs = jobRepository.Get().Where(j => j.Contractor?.Id == request.ContractorId);

            var assignedJobs = contractorJobs.Where(j => j.Status.IsAssigned);
            var inProgressJobs = contractorJobs.Where(j => j.Status.IsInProgress);
            var completedJobs = contractorJobs.Where(j => j.Status.IsCompleted);

            var completedJobsAverageRating = completedJobs.Select(j => j.CompletionInfo?.Rating).Average();

            return Task.FromResult(new GetContractorStatisticsDto
            {
                AssignedJobs = assignedJobs.Count(),
                InProgressJobs = inProgressJobs.Count(),
                CompletedJobs = completedJobs.Count(),
                AverageRating = completedJobsAverageRating
            });
        }
    }
}
