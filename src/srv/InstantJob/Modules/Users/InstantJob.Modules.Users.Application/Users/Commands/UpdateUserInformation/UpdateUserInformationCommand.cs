using MediatR;

namespace InstantJob.Modules.Users.Application.Users.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommand : IRequest
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public int? Age { get; set; }

        public string Picture { get; set; }

        public string Description { get; set; }
    }
}
