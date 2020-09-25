using MediatR;
using System;

namespace InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorJobsInfo
{
    public class GetContractorJobsInfoQuery : IRequest<ContractorJobsInfoDto>
    {
        public GetContractorJobsInfoQuery(Guid contractorId)
        {
            ContractorId = contractorId;
        }

        public Guid ContractorId { get; set; }
    }
}
