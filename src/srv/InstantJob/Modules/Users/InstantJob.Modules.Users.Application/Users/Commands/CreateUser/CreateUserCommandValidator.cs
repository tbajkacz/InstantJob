using FluentValidation;
using InstantJob.Modules.Users.Application.UserRegistrations.Abstractions;

namespace InstantJob.Modules.Users.Application.Users.Commands.CreateUser
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
