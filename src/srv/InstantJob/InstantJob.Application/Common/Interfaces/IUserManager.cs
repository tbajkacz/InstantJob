using InstantJob.Core.Users.Commands.ChangeUserPassword;
using InstantJob.Core.Users.Commands.CreateUser;
using InstantJob.Core.Users.Commands.UpdateUserInformation;
using InstantJob.Core.Users.Queries.FindUserByCredentials;
using InstantJob.Domain.Users.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantJob.Core.Common.Interfaces
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
