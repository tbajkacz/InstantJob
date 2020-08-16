using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Commands.WithdrawJobApplication
{
    public class WithdrawJobApplicationCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
