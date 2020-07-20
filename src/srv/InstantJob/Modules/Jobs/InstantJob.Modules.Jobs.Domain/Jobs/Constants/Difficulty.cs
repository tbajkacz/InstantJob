using InstantJob.BuildingBlocks.Domain;

namespace InstantJob.Modules.Jobs.Domain.Jobs.Constants
{
    public class Difficulty : Enumeration
    {
        public static readonly Difficulty Beginner = new Difficulty(1, "Beginner");
        public static readonly Difficulty Intermediate = new Difficulty(2, "Intermediate");
        public static readonly Difficulty Expert = new Difficulty(3, "Expert");

        protected Difficulty(int id, string name)
            : base(id, name)
        {
        }
    }
}
