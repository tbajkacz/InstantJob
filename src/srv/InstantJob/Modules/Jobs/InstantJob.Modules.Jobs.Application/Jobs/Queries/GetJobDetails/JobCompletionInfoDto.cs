using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Jobs.Domain.Jobs.Entities;
using System;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetJobDetails
{
    public class JobCompletionInfoDto : IMapFrom<CompletionInfo>
    {
        public DateTime? CompletionDate { get; set; }

        public string Comment { get; set; }

        public int? Rating { get; set; }
    }
}
