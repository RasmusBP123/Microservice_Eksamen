using Domain.Core;
using Domain.Core.EventStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core
{
    public interface IRepository<T> where T : AggregateRoot
    {
        void Save(AggregateRoot aggregateRoot, int expectedVersion);
        T GetById(Guid aggregateId);
    }

    public class Repository<T> : IRepository<T> where T : AggregateRoot
    { 
        private readonly IEventStore _eventStore;

        public Repository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public T GetById(Guid aggregateId)
        {
            return _eventStore.GetEventsForAggregate(aggregateId);
        }

        public void Save(AggregateRoot aggregateRoot, int expectedVersion)
        {
            _eventStore.SaveEvents(aggregateRoot.Id, expectedVersion, aggregateRoot.DomainEvents);
        }
    }
}
