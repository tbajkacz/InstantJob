using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using System;
using System.Collections.Generic;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetContractorStatistics
{
    public class GetContractorStatisticsDto
    {
        public int ApplicationsCount { get; set; }

        public int AssignedJobsCount { get; set; }

        public int InProgressJobsCount { get; set; }

        public int CompletedJobsCount { get; set; }

        public double? AverageRating { get; set; }

        public List<StatisticsJobOverviewDto> CompletedJobs { get; set; }

        public List<StatisticsJobOverviewDto> AssignedJobs { get; set; }

        public List<StatisticsJobOverviewDto> InProgressJobs { get; set; }

        public List<StatisticsApplicationDto> ActiveApplications { get; set; }
    }
    
    public class StatisticsJobOverviewDto : IMapFrom<Job>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }

    public class StatisticsApplicationDto
    {
        public Guid JobId { get; set; }

        public string JobTitle { get; set; }
    }
}
