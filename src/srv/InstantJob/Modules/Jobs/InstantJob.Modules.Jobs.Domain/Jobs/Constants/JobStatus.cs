using InstantJob.Domain.Common;

namespace InstantJob.Domain.Jobs.Constants
{
    //TODO this could be a valueobject (check modular monolith)
    public class JobStatus : Enumeration
    {
        public static readonly JobStatus Available = new JobStatus(1, "Available");
        public static readonly JobStatus Assigned = new JobStatus(2, "Assigned");
        public static readonly JobStatus InProgress = new JobStatus(3, "InProgress");
        public static readonly JobStatus Completed = new JobStatus(4, "Completed");
        public static readonly JobStatus Canceled = new JobStatus(5, "Canceled");

        public bool IsInProgress => Name == InProgress.Name;
        public bool IsAssigned => Name == Assigned.Name;
        public bool IsCompleted => Name == Completed.Name;
        public bool IsAvailable => Name == Available.Name;
        public bool IsCanceled => Name == Canceled.Name;

        protected JobStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
