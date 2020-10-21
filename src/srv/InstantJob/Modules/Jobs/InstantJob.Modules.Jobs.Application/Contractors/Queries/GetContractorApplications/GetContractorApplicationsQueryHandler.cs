using AutoMapper;
using InstantJob.Modules.Jobs.Application.Contractors.Abstractions;
using InstantJob.Modules.Jobs.Application.Jobs.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorApplications
{
    public class GetContractorApplicationsQueryHandler : IRequestHandler<GetContractorApplicationsQuery, IEnumerable<ContractorApplicationDto>>
    {
        private readonly IJobRepository jobRepository;
        private readonly ICurrentContractorService currentContractor;

        public GetContractorApplicationsQueryHandler(
            IJobRepository jobRepository,
            ICurrentContractorService currentContractor)
        {
            this.jobRepository = jobRepository;
            this.currentContractor = currentContractor;
        }

        public Task<IEnumerable<ContractorApplicationDto>> Handle(GetContractorApplicationsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(jobRepository.Get()
                .Where(j => j.Status.IsAvailable)
                .SelectMany(j => j.Applications.Where(a => a.Status.IsActive && a.Contractor.Id == currentContractor.Id)
                    .Select(a => new ContractorApplicationDto { JobId = j.Id, JobTitle = j.Title, ApplicationDate = a.ApplicationDate })));
        }
    }
}
