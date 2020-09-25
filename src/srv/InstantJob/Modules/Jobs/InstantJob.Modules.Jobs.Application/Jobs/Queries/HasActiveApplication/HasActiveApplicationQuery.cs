using MediatR;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.HasActiveApplication
{
    public class HasActiveApplicationQuery : IRequest<HasActiveApplicationDto>
    {
        public Guid JobId { get; set; }
    }
}
