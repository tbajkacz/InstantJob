using MediatR;
using System;

namespace InstantJob.Core.Jobs.Commands.AssignContractor
{
    public class AssignContractorCommand : IRequest
    {
        public int ContractorId { get; set; }

        public Guid JobId { get; set; }
    }
}
