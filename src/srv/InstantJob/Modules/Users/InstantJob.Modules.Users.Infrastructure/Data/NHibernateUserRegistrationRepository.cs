using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Users.Application.Interfaces;
using InstantJob.Modules.Users.Domain.UserRegistrations;
using NHibernate;

namespace InstantJob.Modules.Users.Infrastructure.Data
{
    public class NHibernateUserRegistrationRepository : NHibernateRepositoryBase<UserRegistration, int>, IUserRegistrationRepository
    {
        public NHibernateUserRegistrationRepository(ISession session) 
            : base(session)
        {
        }
    }
}
