using MediatR;
using System.Collections.Generic;

namespace InstantJob.Modules.Jobs.Application.Contractors.Queries.GetContractorApplications
{
    public class GetContractorApplicationsQuery : IRequest<IEnumerable<ContractorApplicationDto>>
    {
    }
}
