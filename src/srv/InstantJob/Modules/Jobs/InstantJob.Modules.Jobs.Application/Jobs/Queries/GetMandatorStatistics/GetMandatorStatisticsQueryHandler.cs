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

        public GetMandatorStatisticsQueryHandler(IJobRepository jobRepository)
        {
            this.jobRepository = jobRepository;
        }

        public Task<GetMandatorStatisticsDto> Handle(GetMandatorStatisticsQuery request, CancellationToken cancellationToken)
        {
            if (request.MandatorId == null)
            {
                return Task.FromResult(new GetMandatorStatisticsDto());
            }

            var mandatorJobs = jobRepository.Get().Where(j => j.Mandator.Id == request.MandatorId);

            return Task.FromResult(new GetMandatorStatisticsDto { PostedJobs = mandatorJobs.Count() });
        }
    }
}
