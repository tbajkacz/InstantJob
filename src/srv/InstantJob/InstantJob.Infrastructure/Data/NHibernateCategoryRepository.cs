using InstantJob.Core.Categories.Entities;
using InstantJob.Core.Common.Interfaces;
using NHibernate;

namespace InstantJob.Infrastructure.Data
{
    public class NHibernateCategoryRepository : NHibernateRepositoryBase<Category, int>, ICategoryRepository
    {
        public NHibernateCategoryRepository(ISession session)
            : base(session)
        {
        }
    }
}
