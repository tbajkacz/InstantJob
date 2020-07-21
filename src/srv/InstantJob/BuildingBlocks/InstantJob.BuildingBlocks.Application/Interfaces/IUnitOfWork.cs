using System;
using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();

        Task CommitAsync();

        Task RollbackAsync();

        bool Active { get; }
    }
}
