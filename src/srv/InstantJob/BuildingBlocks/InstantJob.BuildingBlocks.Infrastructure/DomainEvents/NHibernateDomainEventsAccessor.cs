using System.Collections.Generic;
using System.Linq;
using InstantJob.BuildingBlocks.Application.DomainEvents;
using InstantJob.BuildingBlocks.Domain;
using NHibernate;
using NHibernate.Engine;

namespace InstantJob.BuildingBlocks.Infrastructure.DomainEvents
{
    public class NHibernateDomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly ISession session;

        public NHibernateDomainEventsAccessor(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<IDomainEvent> PopUnhandledDomainEvents()
        {
            //The entities are currently in memory so the domain events were not lost
            var modifiedEntities = GetDirtyDomainEntities();

            var domainEvents = modifiedEntities
                .SelectMany(e => e.DomainEvents)
                .ToList();

            //Database update is not required in this case as the domain events are not persisted
            modifiedEntities.ForEach(e => e.ClearDomainEvents());

            return domainEvents;
        }

        private List<BaseEntity> GetDirtyDomainEntities()
        {
            var modifiedEntities = new List<BaseEntity>();
            var sessionImplementor = session.GetSessionImplementation();
            foreach (EntityEntry entityEntry in sessionImplementor.PersistenceContext.EntityEntries.Values)
            {
                var loadedState = entityEntry.LoadedState;
                var currentObject = sessionImplementor.PersistenceContext.GetEntity(entityEntry.EntityKey);
                var currentState = entityEntry.Persister.GetPropertyValues(currentObject);

                if (entityEntry.Persister.FindDirty(currentState, loadedState, currentObject, sessionImplementor) != null &&
                    currentObject is BaseEntity entity)
                {
                    modifiedEntities.Add(entity);
                }
            }

            return modifiedEntities;
        }
    }
}
