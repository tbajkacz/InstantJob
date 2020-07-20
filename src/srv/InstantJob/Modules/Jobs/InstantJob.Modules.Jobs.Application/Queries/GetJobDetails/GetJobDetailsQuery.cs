﻿using System;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Queries.GetJobDetails
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
