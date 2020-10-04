using InstantJob.Modules.Jobs.Domain.Jobs.Constants;

namespace InstantJob.Modules.Jobs.Application.Jobs.Queries.GetAvailableJobs
{
    public class JobStatusQuery : JobStatus
    {
        public static readonly JobStatus Any = new JobStatusQuery(90, "Any");

        protected JobStatusQuery(int id, string name)
            : base(id, name)
        {
        }
    }
}
