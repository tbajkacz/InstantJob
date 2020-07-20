using System;

namespace InstantJob.Core.Common.Exceptions
{
    public class InvalidUserSessionException : Exception
    {
        public InvalidUserSessionException()
            : base("Current session is expired or invalid")
        {
        }
    }
}
