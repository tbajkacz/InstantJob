﻿using AutoMapper;
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
        private readonly IMapper mapper;

        public GetContractorStatisticsQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
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
            var applicationsCount = jobRepository.Get().Where(j => j.Status.IsAvailable && j.Applications.Any(a => a.Status.IsActive && a.Contractor.Id == request.ContractorId)).Count();

            var completedJobsAverageRating = completedJobs.Select(j => j.CompletionInfo?.Rating).Average();

            return Task.FromResult(new GetContractorStatisticsDto
            {
                AssignedJobsCount = assignedJobs.Count(),
                InProgressJobsCount = inProgressJobs.Count(),
                CompletedJobsCount = completedJobs.Count(),
                ApplicationsCount = applicationsCount,
                AverageRating = completedJobsAverageRating,
                CompletedJobs = completedJobs.Select(j => mapper.Map<StatisticsJobOverviewDto>(j)).ToList(),
                InProgressJobs = inProgressJobs.Select(j => mapper.Map<StatisticsJobOverviewDto>(j)).ToList(),
                AssignedJobs = assignedJobs.Select(j => mapper.Map<StatisticsJobOverviewDto>(j)).ToList(),
                ActiveApplications = jobRepository.Get().Where(j => j.Status.IsAssigned && j.Applications.Any(a => a.Status.IsActive && a.Contractor.Id == request.ContractorId)).Select(j => new StatisticsApplicationDto
                {
                    JobId = j.Id,
                    JobTitle = j.Title
                }).ToList()
            });
        }
    }
}
