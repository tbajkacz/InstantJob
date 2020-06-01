namespace InstantJob.Core.Users.Dtos
{
    public class UserUpdateInfoParams
    {
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual int? Age { get; set; }

        public virtual string Picture { get; set; }
    }
}
