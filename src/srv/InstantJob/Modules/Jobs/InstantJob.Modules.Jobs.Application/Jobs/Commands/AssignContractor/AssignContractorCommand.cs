using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.AssignContractor
{
    public class AssignContractorCommand : IRequest
    {
        public Guid ContractorId { get; set; }

        public Guid JobId { get; set; }
    }
}
