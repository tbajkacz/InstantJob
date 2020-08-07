using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.AssignContractor
{
    public class AssignContractorCommand : IRequest
    {
        public Guid ContractorId { get; set; }

        public Guid JobId { get; set; }
    }
}
