﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails
{
    public class GetJobDetailsQueryHandler : IRequestHandler<GetJobDetailsQuery, JobDetailsDto>
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public GetJobDetailsQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public async Task<JobDetailsDto> Handle(GetJobDetailsQuery request, CancellationToken cancellationToken)
        {
            var job = await jobRepository.GetByIdAsync(request.Id);

            var dto = mapper.Map<JobDetailsDto>(job);
            dto.Applications = dto.Applications.Where(a => a.Status == ApplicationStatus.Active).ToList();

            return dto;
        }
    }
}
