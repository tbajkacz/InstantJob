﻿using System;
using System.Collections.Generic;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails
{
    public class JobDetailsDto : IMapFrom<Job>
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public IList<JobDetailsApplicationDto> Applications { get; set; }

        public decimal? Price { get; set; }

        public DateTime PostedDate { get; set; }

        public DateTime Deadline { get; set; }

        public Difficulty Difficulty { get; set; }

        public bool WasCanceled { get; set; }

        public JobDetailsCategoryDto Category { get; set; }

        public JobDetailsMandatorDto Mandator { get; set; }

        public JobDetailsContractorDto Contractor { get; set; }

        public bool IsCompleted { get; set; }

        public bool IsInProgress { get; set; }
    }
}
