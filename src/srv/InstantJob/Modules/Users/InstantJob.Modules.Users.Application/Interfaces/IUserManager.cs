using System.Collections.Generic;
using System.Threading.Tasks;
using InstantJob.Modules.Users.Application.Commands.ChangeUserPassword;
using InstantJob.Modules.Users.Application.Commands.CreateUser;
using InstantJob.Modules.Users.Application.Commands.UpdateUserInformation;
using InstantJob.Modules.Users.Application.Queries.FindUserByCredentials;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface IUserManager
    {
        Task CreateAsync(CreateUserCommand param);

        Task CreateAsync(User user, string password);

        Task UpdateAsync(User user);

        Task<User> ValidateCredentialsAsync(FindUserByCredentialsQuery param);

        Task UpdatePasswordAsync(ChangeUserPasswordCommand param);

        Task UpdateInformationAsync(UpdateUserInformationCommand param);

        IEnumerable<User> Users { get; }
    }
}
