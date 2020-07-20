using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using InstantJob.Modules.Jobs.Application.Interfaces;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Queries.GetJobDetails
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
            return mapper.Map<JobDetailsDto>(job);
        }
    }
}
