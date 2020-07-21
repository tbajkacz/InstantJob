using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using NHibernate;

namespace InstantJob.BuildingBlocks.Infrastructure.Data
{
    public sealed class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private readonly ITransaction transaction;

        public bool Active => transaction.IsActive;

        public NHibernateUnitOfWork(ISession session)
        {
            this.session = session;
            transaction = session.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await transaction.RollbackAsync();
        }


        public void Dispose()
        {
            transaction?.Dispose();
            session.Dispose();
        }
    }
}
