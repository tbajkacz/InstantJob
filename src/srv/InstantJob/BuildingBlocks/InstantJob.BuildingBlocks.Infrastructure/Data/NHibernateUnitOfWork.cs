using System.Threading.Tasks;
using InstantJob.BuildingBlocks.Application.Interfaces;
using NHibernate;

namespace InstantJob.BuildingBlocks.Infrastructure.Data
{
    public sealed class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private ITransaction transaction;

        public bool Active => transaction?.IsActive ?? false;

        public NHibernateUnitOfWork(ISession session)
        {
            this.session = session;
        }

        public void BeginTransaction()
        {
            transaction = session.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await transaction.CommitAsync();
            transaction.Dispose();
            transaction = null;
        }

        public async Task RollbackAsync()
        {
            await transaction.RollbackAsync();
            transaction.Dispose();
            transaction = null;
        }


        public void Dispose()
        {
            transaction?.Dispose();
            session.Dispose();
        }
    }
}
