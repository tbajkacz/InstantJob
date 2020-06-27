using InstantJob.Domain.Common;

namespace InstantJob.Domain.Users.Entities
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

        //TODO when deleting a user publish the id in order to delete the jobs he created
        //if he was in progress with some jobs then take action as well

        //TODO user may have multiple types, to become mandator one may need to provide additional data
    }
}
