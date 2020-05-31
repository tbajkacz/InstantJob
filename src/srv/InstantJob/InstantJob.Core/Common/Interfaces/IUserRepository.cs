using InstantJob.Core.Users.Dtos;
using InstantJob.Core.Users.Entities;
using System.Threading.Tasks;

namespace InstantJob.Core.Common.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> ValidateCredentialsAsync(UserAuthParams param);

        Task UpdatePasswordAsync(UserUpdatePasswordParams param);
    }
}
