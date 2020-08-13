using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserById
{
    public class UserDetailsDto : IMapFrom<User>
    {
        public string Name { get; protected set; }

        public string Surname { get; protected set; }

        public int? Age { get; protected set; }

        public string Email { get; protected set; }

        public string Picture { get; protected set; }
    }
}
