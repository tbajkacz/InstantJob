namespace InstantJob.BuildingBlocks.Domain
{
    public class Role : Enumeration
    {
        public static readonly Role Mandator = new Role(1, "Mandator");
        public static readonly Role Contractor = new Role(2, "Contractor");
        public static readonly Role Administrator = new Role(3, "Administrator");

        protected Role(int id, string name)
            : base(id, name)
        {
        }
    }
}
