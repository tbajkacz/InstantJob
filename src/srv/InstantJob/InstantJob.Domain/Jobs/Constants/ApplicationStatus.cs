using InstantJob.Domain.Common;

namespace InstantJob.Domain.Jobs.Constants
{
    public class ApplicationStatus : Enumeration
    {
        public static readonly ApplicationStatus Active = new ApplicationStatus(1, "Active");
        public static readonly ApplicationStatus Withdrawn = new ApplicationStatus(2, "Withdrawn");

        protected ApplicationStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
