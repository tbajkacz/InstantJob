using System.Collections.Generic;

namespace InstantJob.Core.Common.Interfaces
{
    public interface ICurrentUserService
    {
        int UserId { get; }

        IEnumerable<string> Roles { get; }

        string Email { get; }
    }
}
