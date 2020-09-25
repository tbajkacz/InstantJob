using AutoMapper;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorJobsInfo
{
    public class ContractorJobsQueryHandler : IRequestHandler<GetContractorJobsInfoQuery, ContractorJobsInfoDto>
    {
        private readonly IJobRepository jobRepository;
        private readonly IMapper mapper;

        public ContractorJobsQueryHandler(IJobRepository jobRepository, IMapper mapper)
        {
            this.jobRepository = jobRepository;
            this.mapper = mapper;
        }

        public Task<ContractorJobsInfoDto> Handle(GetContractorJobsInfoQuery request, CancellationToken cancellationToken)
        {
            var jobs = jobRepository.Get();

            var contractorJobsInfo = jobs.Where(c => c.Contractor.Id == request.ContractorId)
                .Select(mapper.Map<ContractorJobsInfoJobDto>)
                .ToList();

            return Task.FromResult(new ContractorJobsInfoDto { Jobs = contractorJobsInfo });
        }
    }
}
