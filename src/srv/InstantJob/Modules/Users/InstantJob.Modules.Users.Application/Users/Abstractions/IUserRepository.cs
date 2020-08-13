using System;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;

namespace InstantJob.Modules.Users.Application.Users.Abstractions
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        Task<User> GetByEmailOrDefaultAsync(string email);
    }
}
