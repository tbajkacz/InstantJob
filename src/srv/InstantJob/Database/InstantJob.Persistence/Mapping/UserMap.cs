using InstantJob.Modules.Users.Domain.Entities;

namespace InstantJob.Database.Persistence.Mapping
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
                .Not.Nullable()
                .Unique();
            Map(x => x.Picture);
            Map(x => x.Verified);
            HasMany(x => x.Roles)
                .Table("Roles")
                .Element("Role");
        }
    }
}
