using MediatR;

namespace InstantJob.Core.Users.Commands
{
    public class UpdateUserInformationCommand : IRequest
    {
        public virtual string Name { get; set; }

        public virtual string Surname { get; set; }

        public virtual int? Age { get; set; }

        public virtual string Picture { get; set; }
    }
}
