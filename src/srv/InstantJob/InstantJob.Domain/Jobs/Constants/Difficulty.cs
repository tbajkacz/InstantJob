using InstantJob.Domain.Common;
using System.Linq;

namespace InstantJob.Domain.Jobs.Constants
{
    public class Difficulty : Enumeration
    {
        public static readonly Difficulty Beginner = new Difficulty(0, "Beginner");
        public static readonly Difficulty Intermediate = new Difficulty(1, "Intermediate");
        public static readonly Difficulty Expert = new Difficulty(2, "Expert");

        protected Difficulty(int id, string name)
            : base(id, name)
        {
        }

        public static explicit operator int(Difficulty difficulty) => difficulty.Id;
        public static explicit operator Difficulty(int id) => GetAll<Difficulty>().Single(x => x.Id == id);
    }
}
