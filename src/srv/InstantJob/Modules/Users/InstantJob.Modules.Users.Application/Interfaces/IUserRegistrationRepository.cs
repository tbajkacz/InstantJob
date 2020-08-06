using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;

namespace InstantJob.Modules.Users.Application.Interfaces
{
    public interface IUserRegistrationRepository : IRepository<UserRegistration, int>
    {
        Task<int> NextIdAsync();
    }
}
