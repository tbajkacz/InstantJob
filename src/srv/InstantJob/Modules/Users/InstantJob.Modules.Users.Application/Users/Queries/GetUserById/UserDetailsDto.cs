using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserById
{
    public class UserDetailsDto : IMapFrom<User>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Age { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public Role Role { get; set; }
    }
}
