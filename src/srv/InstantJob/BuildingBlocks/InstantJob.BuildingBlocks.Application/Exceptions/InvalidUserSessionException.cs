using System;

namespace InstantJob.BuildingBlocks.Application.Exceptions
{
    public class InvalidUserSessionException : Exception
    {
        public InvalidUserSessionException()
            : base("Current session is expired or invalid")
        {
        }
    }
}
