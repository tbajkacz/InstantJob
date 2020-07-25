using InstantJob.Database.Persistence.CustomTypes;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Database.Persistence.Mapping
{
    public class UserRegistrationMap : BaseEntityMap<UserRegistration, int>
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
