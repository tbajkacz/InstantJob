using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs
{
    public class GetAvailableJobsQueryHandler : IRequestHandler<GetAvailableJobsQuery, IEnumerable<JobOverviewDto>>
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public GetAvailableJobsQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public Task<IEnumerable<JobOverviewDto>> Handle(GetAvailableJobsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(
                jobRepository.Get(
                    request.CategoryId,
                    request.ContractorId,
                    request.MandatorId,
                    request.DifficultyId,
                    request.SearchString,
                    request.Status,
                    request.IncludeExpired ?? false,
                    request.Skip,
                    request.Count
                    )
                .Select(mapper.Map<JobOverviewDto>));    
        }
    }
}
