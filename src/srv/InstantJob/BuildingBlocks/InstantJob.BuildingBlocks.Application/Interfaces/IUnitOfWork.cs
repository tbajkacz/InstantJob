using System;
using System.Threading.Tasks;

namespace InstantJob.Core.Common.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();

        Task RollbackAsync();

        bool Active { get; }
    }
}
