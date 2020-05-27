using SharedKernel.Types;

namespace InstantJob.Core.Entities.UserAggregate
{
    public class User : BaseEntity<int>
    {
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual int? Age { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string Email { get; set; }

        public virtual string Picture { get; set; }

        public virtual bool Verified { get; set; }

        public virtual string Type { get; set; }
    }
}
