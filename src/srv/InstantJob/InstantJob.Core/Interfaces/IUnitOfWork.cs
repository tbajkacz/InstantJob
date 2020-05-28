using System;
using System.Threading.Tasks;

namespace InstantJob.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}
