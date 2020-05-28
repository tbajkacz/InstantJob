using System;

namespace InstantJob.Core.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(Type entityType, object id)
            : base($"Entity of type {entityType.FullName} with id {id} was not found")
        {
        }
    }
}
