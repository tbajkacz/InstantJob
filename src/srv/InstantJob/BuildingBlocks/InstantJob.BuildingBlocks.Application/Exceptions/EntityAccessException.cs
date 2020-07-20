using System;

namespace InstantJob.BuildingBlocks.Application.Exceptions
{
    public class EntityAccessException : Exception
    {
        public EntityAccessException(object userId, object entityId, Type entityType) 
            : base($"User id {userId} has no access to {entityType.Name} id: {entityId}")
        {
        }
    }
}
