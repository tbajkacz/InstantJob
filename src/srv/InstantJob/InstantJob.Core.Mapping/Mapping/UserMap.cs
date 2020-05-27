using InstantJob.Core.Entities.UserAggregate;

namespace InstantJob.Core.NHibernate.Mapping
{
    internal class UserMap : BaseEntityMap<User, int>
    {
        public UserMap()
        {
            Map(x => x.Name)
                .Not.Nullable();
            Map(x => x.Surname)
                .Not.Nullable();
            Map(x => x.Age);
            Map(x => x.PasswordHash)
                .Not.Nullable();
            Map(x => x.Email)
                .Not.Nullable();
            Map(x => x.Picture);
            Map(x => x.Verified);
            Map(x => x.Type)
                .Not.Nullable();
        }
    }
}
