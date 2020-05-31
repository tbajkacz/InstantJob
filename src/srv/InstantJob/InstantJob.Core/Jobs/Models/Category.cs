using SharedKernel.Types;

namespace InstantJob.Core.Jobs.Models
{
    public class Category : BaseEntity<int>
    {
        public virtual string Name { get; set; }
    }
}
