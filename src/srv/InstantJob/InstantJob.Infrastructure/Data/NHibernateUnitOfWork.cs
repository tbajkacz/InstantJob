﻿using InstantJob.Core.Interfaces;
using NHibernate;
using System.Threading.Tasks;

namespace InstantJob.Infrastructure.Data
{
    public sealed class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession session;
        private readonly ITransaction transaction;

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
            if (transaction != null)
            {
                transaction.Dispose();
            }
            session.Dispose();
        }
    }
}
