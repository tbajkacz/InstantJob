using MediatR;

namespace InstantJob.Modules.Users.Application.Commands.UpdateUserInformation
{
    public class UpdateUserInformationCommand : IRequest
    {
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual int? Age { get; set; }

        public virtual string Picture { get; set; }
    }
}
