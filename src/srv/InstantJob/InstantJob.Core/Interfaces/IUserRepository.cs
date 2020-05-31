using InstantJob.Core.Dtos;
using InstantJob.Core.Users.Models;
using System.Threading.Tasks;

namespace InstantJob.Core.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> ValidateCredentialsAsync(UserAuthParams param);

        Task UpdatePasswordAsync(UserUpdatePasswordParams param);
    }
}
