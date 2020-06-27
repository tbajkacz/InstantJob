using MediatR;
using System;

namespace InstantJob.Core.Jobs.Queries.GetJobDetails
{
    public class GetJobDetailsQuery : IRequest<JobDetailsDto>
    {
        public GetJobDetailsQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
