using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Commands.AcceptJobAssignment
{
    public class AcceptJobAssignmentCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
