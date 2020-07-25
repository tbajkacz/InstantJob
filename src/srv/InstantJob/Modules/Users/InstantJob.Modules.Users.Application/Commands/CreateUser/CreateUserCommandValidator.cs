using FluentValidation;
using InstantJob.Modules.Users.Application.Interfaces;

namespace InstantJob.Modules.Users.Application.Commands.CreateUser
{
    public class CreateUserCommandValidator : BaseUserValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator(IUserRegistrationRepository repository)
        {
            RuleFor(x => x.UserRegistrationId)
                .MustAsync(async (x, c) => await repository.GetByIdOrDefaultAsync(x) != null);
        }
    }
}
