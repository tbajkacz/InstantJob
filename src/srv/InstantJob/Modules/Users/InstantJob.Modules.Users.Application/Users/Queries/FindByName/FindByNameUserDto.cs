using InstantJob.BuildingBlocks.Application.Automapper;
using InstantJob.Modules.Users.Domain.Users;
using System;

namespace InstantJob.Modules.Users.Application.Users.Queries.FindByName
{
    public class FindByNameUserDto : IMapFrom<User>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }
    }
}
