using SharedKernel.Types;

namespace InstantJob.Core.Entities
{
    public class Category : BaseEntity<int>
    {
        public virtual string Name { get; set; }
    }
}
