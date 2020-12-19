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

        public List<ContractorStatisticsJobOverviewDto> CompletedJobs { get; set; }

        public List<ContractorStatisticsJobOverviewDto> AssignedJobs { get; set; }

        public List<ContractorStatisticsJobOverviewDto> InProgressJobs { get; set; }

        public List<ContractorStatisticsApplicationDto> ActiveApplications { get; set; }
    }
    
    public class ContractorStatisticsJobOverviewDto : IMapFrom<Job>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }

    public class ContractorStatisticsApplicationDto
    {
        public Guid JobId { get; set; }

        public string JobTitle { get; set; }
    }
}
