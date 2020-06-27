using InstantJob.Core.Common.Interfaces;
using InstantJob.Domain.Categories.Entities;
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
