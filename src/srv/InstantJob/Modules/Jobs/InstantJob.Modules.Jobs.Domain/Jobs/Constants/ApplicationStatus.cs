using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Constants
{
    public class ApplicationStatus : Enumeration
    {
        public static readonly ApplicationStatus Active = new ApplicationStatus(1, "Active");
        public static readonly ApplicationStatus Withdrawn = new ApplicationStatus(2, "Withdrawn");

        public bool IsActive => Name == Active.Name;

        protected ApplicationStatus(int id, string name)
            : base(id, name)
        {
        }
    }
}
