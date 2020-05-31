using System.Threading.Tasks;
using InstantJob.Core.Dtos;
using InstantJob.Core.Interfaces;
using InstantJob.Core.Users.Models;
using NHibernate;
using NHibernate.Linq;

namespace InstantJob.Infrastructure.Data
{
    public class NHibernateUserRepository : NHibernateRepositoryBase<User, int>, IUserRepository
    {
        private readonly IHashService hashService;

        public NHibernateUserRepository(ISession session, IHashService hashService)
            : base(session)
        {
            this.hashService = hashService;
        }

        public async Task UpdatePasswordAsync(UserUpdatePasswordParams param)
        {
            var user = await GetByIdAsync(param.Id);
            user.PasswordHash = hashService.Hash(param.Password);
            await UpdateAsync(user);
        }

        public async Task<User> ValidateCredentialsAsync(UserAuthParams param)
        {
            var user = await session.Query<User>()
                .SingleOrDefaultAsync(u => u.Email == param.Email);

            return user == null ? null : hashService.CompareHashes(param.Password, user.PasswordHash) ? user : null;
        }
    }
}
