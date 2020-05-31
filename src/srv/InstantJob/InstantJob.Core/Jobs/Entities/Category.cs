using SharedKernel.Types;

namespace InstantJob.Core.Jobs.Entities
{
    public class Category : BaseEntity<int>
    {
        public virtual string Name { get; set; }
    }
}
