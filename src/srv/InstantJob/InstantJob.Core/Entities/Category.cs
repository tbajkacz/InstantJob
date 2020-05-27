using SharedKernel.Types;

namespace InstantJob.Core.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
