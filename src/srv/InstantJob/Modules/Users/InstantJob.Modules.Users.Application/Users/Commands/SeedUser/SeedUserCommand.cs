using InstantJob.BuildingBlocks.Domain;
using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Commands.SeedUser
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
