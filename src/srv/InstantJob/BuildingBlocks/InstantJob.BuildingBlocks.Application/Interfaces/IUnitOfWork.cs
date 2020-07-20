using System;
using System.Threading.Tasks;

namespace InstantJob.BuildingBlocks.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();

        Task RollbackAsync();

        bool Active { get; }
    }
}
