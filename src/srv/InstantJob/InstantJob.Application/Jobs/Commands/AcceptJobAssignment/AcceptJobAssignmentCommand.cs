using MediatR;
using System;

namespace InstantJob.Application.Jobs.Commands.AcceptJobAssignment
{
    public class AcceptJobAssignmentCommand : IRequest
    {
        public Guid JobId { get; set; }
    }
}
