using InstantJob.BuildingBlocks.Domain;
using InstantJob.Modules.Users.Domain.Users;
using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.SeedUser
{
    public class SeedUserCommand : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }
    }
}
