using InstantJob.Core.Users.Dtos;
using InstantJob.Core.Users.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstantJob.Core.Common.Interfaces
{
    public interface IUserManager
    {
        Task CreateAsync(UserRegisterParams param);

        Task CreateAsync(User user, string password);

        Task UpdateAsync(User user);

        Task<User> ValidateCredentialsAsync(UserAuthParams param);

        Task UpdatePasswordAsync(UserUpdatePasswordParams param);

        IEnumerable<User> Users { get; }
    }
}
