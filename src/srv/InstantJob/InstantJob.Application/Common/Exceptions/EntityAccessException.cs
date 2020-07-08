using System;

namespace InstantJob.Core.Common.Exceptions
{
    public class EntityAccessException : Exception
    {
        public EntityAccessException(object userId, object entityId, Type entityType) 
            : base($"User id {userId} has no access to {entityType.Name} id: {entityId}")
        {
        }
    }
}
