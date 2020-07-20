using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Entities;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface IUserRepository : IRepository<User, int>
    {
        Task<User> FindByEmailAsync(string email);
    }
}
