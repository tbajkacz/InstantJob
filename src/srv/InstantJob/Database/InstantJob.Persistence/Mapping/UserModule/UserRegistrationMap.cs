using System;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Database.Persistence.CustomTypes;
using InstantJob.Modules.Users.Domain.UserRegistrations;

namespace InstantJob.Database.Persistence.Mapping.UserModule
{
    public class UserRegistrationMap : BaseEntityMap<UserRegistration, Guid>
    {
        public UserRegistrationMap()
        {
            Map(x => x.Name)
                .Not.Nullable();
            Map(x => x.Surname)
                .Not.Nullable();
            Map(x => x.Email)
                .Not.Nullable();
            Map(x => x.PasswordHash)
                .Not.Nullable();
            Map(x => x.Confirmed);
            Map(x => x.Role)
                .CustomType<EnumerationType<Role>>()
                .Not.Nullable();
        }
    }
}
