using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using NHibernate;
using NHibernate.Linq;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class NHibernateUserRegistrationRepository : NHibernateRepositoryBase<UserRegistration, int>, IUserRegistrationRepository
    {
        public NHibernateUserRegistrationRepository(ISession session) 
            : base(session)
        {
        }

        //Using a method instead of NHibernate IIdConvention allows to control the ids of certain entities
        //System.NotSupportedException: 'The DefaultIfEmptyResultOperator  NHIBERNATE DOES NOT SUPPORT DefaultIfEmpty............
        //TODO Switch to EF...
        public async Task<int> NextIdAsync()
        {
            var itemCount = await session.Query<UserRegistration>()
                    .CountAsync();

            return itemCount == 0
                ? 1
                : await session.Query<UserRegistration>()
                    .MaxAsync(r => r.Id);
        }
    }
}
