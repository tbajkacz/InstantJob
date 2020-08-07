using System;
using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.Users;
using NHibernate;
using NHibernate.Linq;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class NHibernateUserRepository : NHibernateRepositoryBase<User, Guid>, IUserRepository
    {
        public NHibernateUserRepository(ISession session)
            : base(session)
        {
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await session.Query<User>()
                .SingleOrDefaultAsync(u => u.Email == email);
        }
    }
}
