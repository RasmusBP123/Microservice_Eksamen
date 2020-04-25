using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.EventStore
{
    public interface IEventStore
    {
        void SaveEvents(Guid aggregateId, int expectedVersion, IEnumerable<IEvent> events);
        List<Event> GetEventsForAggregate(Guid aggregateId);
    }

    public class EventStore : IEventStore
    {
        private struct EventDescriptor
        {
            public readonly Event EventData;
            public readonly Guid Id;
            public readonly int Version;

            public EventDescriptor(Guid id, Event eventData, int version)
            {
                EventData = eventData;
                Version = version;
                Id = id;
            }
        }

        public EventStore(ProductDbContext context)
        {
            _context = context;
        }

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();
        private readonly ProductDbContext _context;

        public List<Event> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;

            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }

            return eventDescriptors.Select(desc => desc.EventData).ToList();
        }

        public void SaveEvents(Guid aggregateId, int expectedVersion, IEnumerable<IEvent> events)
        {
            List<EventDescriptor> eventDescriptors;

            // try to get event descriptors list for given aggregate id
            // otherwise -> create empty dictionary
            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                eventDescriptors = new List<EventDescriptor>();
                _current.Add(aggregateId, eventDescriptors);
            }

            else if(eventDescriptors[eventDescriptors.Count - 1].Version != expectedVersion && expectedVersion != -1)
            {
                throw new Exception();
            }

            var listOfEvents = events.Select(ev => new Event
            {
                Id = Guid.NewGuid(),
                Version = expectedVersion,
                TimeStamp = DateTime.UtcNow,
                Name = ev.GetType().Name,
                AggregateRootId = aggregateId
            });

            _context.Events.AddRange(listOfEvents);

            _context.SaveChanges();
        }
    }

    public class AggregateNotFoundException : Exception
    {
    }

}
