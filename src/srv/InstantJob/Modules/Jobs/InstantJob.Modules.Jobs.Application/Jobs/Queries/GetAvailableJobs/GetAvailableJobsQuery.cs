﻿using System;
using System.Collections.Generic;
using MediatR;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs
{
    public class GetAvailableJobsQuery : IRequest<IEnumerable<JobOverviewDto>>
    {
        public Guid? CategoryId { get; set; }

        public int? DifficultyId { get; set; }

        public string SearchString { get; set; }

        public Guid? MandatorId { get; set; }

        public Guid? ContractorId { get; set; }

        public int? Skip { get; set; }

        public int? Count { get; set; }

        public string Status { get; set; }

        public bool? IncludeExpired { get; set; }
    }
}
