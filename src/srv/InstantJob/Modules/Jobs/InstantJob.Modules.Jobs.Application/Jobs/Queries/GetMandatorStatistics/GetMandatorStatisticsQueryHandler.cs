using AutoMapper;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetMandatorStatistics
{
    public class GetMandatorStatisticsQueryHandler : IRequestHandler<GetMandatorStatisticsQuery, GetMandatorStatisticsDto>
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public GetMandatorStatisticsQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public Task<GetMandatorStatisticsDto> Handle(GetMandatorStatisticsQuery request, CancellationToken cancellationToken)
        {
            if (request.MandatorId == null)
            {
                return Task.FromResult(new GetMandatorStatisticsDto());
            }

            var mandatorPostedJobs = jobRepository.Get().Where(j => j.Mandator.Id == request.MandatorId);
            var mandatorPostedJobsInProgress = mandatorPostedJobs.Where(j => j.Status.IsInProgress);
            var mandatorPostedJobsCompleted = mandatorPostedJobs.Where(j => j.Status.IsCompleted);
            var mandatorPostedJobsWaitingForAssignment = mandatorPostedJobs.Where(j => j.Status.IsAvailable && j.Applications.Count() > 0);

            var result = new GetMandatorStatisticsDto {
                PostedJobsCount = mandatorPostedJobs.Count(),
                PostedJobs = mandatorPostedJobs.Select(mapper.Map<MandatorStatisticsJobOverviewDto>).ToList(),
                PostedJobsInProgressCount = mandatorPostedJobsInProgress.Count(),
                PostedJobsInProgress = mandatorPostedJobsInProgress.Select(mapper.Map<MandatorStatisticsJobOverviewDto>).ToList(),
                PostedJobsWaitingForAssignmentCount = mandatorPostedJobsWaitingForAssignment.Count(),
                PostedJobsWaitingForAssignment = mandatorPostedJobsWaitingForAssignment.Select(mapper.Map<MandatorStatisticsJobOverviewDto>).ToList(),
                PostedJobsCompletedCount = mandatorPostedJobsCompleted.Count(),
                PostedJobsCompleted = mandatorPostedJobsCompleted.Select(mapper.Map<MandatorStatisticsJobOverviewDto>).ToList()
            };

            return Task.FromResult(result);
        }
    }
}
