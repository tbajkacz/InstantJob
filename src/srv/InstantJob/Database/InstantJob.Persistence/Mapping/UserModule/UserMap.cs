using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Database.Persistence.CustomTypes;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Database.Persistence.Mapping.UserModule
{
    internal class UserMap : BaseEntityMap<User, Guid>
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
            Map(x => x.Role)
                .CustomType<EnumerationType<Role>>();
        }
    }
}
