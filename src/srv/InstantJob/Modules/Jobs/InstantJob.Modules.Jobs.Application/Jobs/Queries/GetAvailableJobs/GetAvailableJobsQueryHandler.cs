﻿using System;
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
            return Task.FromResult(jobRepository.Get(request.CategoryId, request.Skip, request.Count)
                .Where(x => x.Status.IsAvailable)
                .Where(x => x.Deadline.HasValue && x.Deadline.Value > DateTime.Now)
                .Select(mapper.Map<JobOverviewDto>));    
        }
    }
}
