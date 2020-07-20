using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.AssignContractor
{
    public class AssignContractorCommand : IRequest
    {
        public int ContractorId { get; set; }

        public Guid JobId { get; set; }
    }
}
