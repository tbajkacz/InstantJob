using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.Users;
using System;

namespace InstantJob.Modules.Users.Application.Users.Queries.GetUserDetails
{
    public class UserDetailsDto : IMapFrom<User>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public Role Role { get; set; }
    }
}
