using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using System;
using System.Collections.Generic;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetMandatorStatistics
{
    public class GetMandatorStatisticsDto
    {
        public int PostedJobsCount { get; set; }

        public int PostedJobsInProgressCount { get; set; }

        public int PostedJobsCompletedCount { get; set; }

        public int PostedJobsWaitingForAssignmentCount { get; set; }

        public List<MandatorStatisticsJobOverviewDto> PostedJobs { get; set; }

        public List<MandatorStatisticsJobOverviewDto> PostedJobsInProgress { get; set; }

        public List<MandatorStatisticsJobOverviewDto> PostedJobsCompleted { get; set; }

        public List<MandatorStatisticsJobOverviewDto> PostedJobsWaitingForAssignment { get; set; }
    }

    public class MandatorStatisticsJobOverviewDto : IMapFrom<Job>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
