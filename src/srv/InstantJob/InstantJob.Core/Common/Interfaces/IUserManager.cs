using InstantJob.Core.Users.Commands;
using InstantJob.Core.Users.Entities;
using InstantJob.Core.Users.Queries;
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
