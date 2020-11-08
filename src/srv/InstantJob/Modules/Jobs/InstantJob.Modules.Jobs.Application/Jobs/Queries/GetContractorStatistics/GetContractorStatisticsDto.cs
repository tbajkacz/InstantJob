namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetContractorStatistics
{
    public class GetContractorStatisticsDto
    {
        public int ApplicationsCount { get; set; }

        public int AssignedJobs { get; set; }

        public int InProgressJobs { get; set; }

        public int CompletedJobs { get; set; }

        public double? AverageRating { get; set; }
    }
}
