using System;
using InstantJob.BuildingBlocks.Infrastructure.Data;
using InstantJob.Modules.Jobs.Application.Categories.Abstractions;
using InstantJob.Modules.Jobs.Domain.Categories;
using NHibernate;

namespace InstantJob.Modules.Jobs.Infrastructure.Data
{
    public class NHibernateCategoryRepository : NHibernateRepositoryBase<Category, Guid>, ICategoryRepository
    {
        public NHibernateCategoryRepository(ISession session)
            : base(session)
        {
        }
    }
}
