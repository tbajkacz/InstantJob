using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Users.Entities;
using NHibernate;
using NHibernate.Linq;
using System.Threading.Tasks;

namespace InstantJob.Infrastructure.Data
{
    public class NHibernateUserRepository : NHibernateRepositoryBase<User, int>, IUserRepository
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
