using System;
using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Constants;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs
{
    public class JobOverviewDto : IMapFrom<Job>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal? Price { get; set; }

        public DateTime PostedDate { get; set; }

        public Difficulty Difficulty { get; set; }

        public JobStatus Status { get; set; }

        public JobOverviewCategoryDto Category { get; set; }

        public JobOverviewMandatorDto Mandator { get; set; }

        public bool HasExpired { get; set; }
    }
}
