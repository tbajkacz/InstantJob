using InstantJob.Domain.Users.Entities;
using System.Threading.Tasks;

namespace InstantJob.Core.Common.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
