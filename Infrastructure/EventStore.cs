using Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactical.DDD;

namespace Infrastructure.EventStore
{
    public interface IEventStore
    {
        void Save(Guid aggregateId, int expectedVersion, IEnumerable<Event> events);
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

        private readonly Dictionary<Guid, List<EventDescriptor>> _current = new Dictionary<Guid, List<EventDescriptor>>();

        public List<Event> GetEventsForAggregate(Guid aggregateId)
        {
            List<EventDescriptor> eventDescriptors;

            if (!_current.TryGetValue(aggregateId, out eventDescriptors))
            {
                throw new AggregateNotFoundException();
            }

            return eventDescriptors.Select(desc => desc.EventData).ToList();
        }

        public void Save(Guid aggregateId, int expectedVersion, IEnumerable<Event> events)
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

            var i = expectedVersion;

            foreach (var @event in events)
            {
                i++;
                @event.Version = i;
                eventDescriptors.Add(new EventDescriptor(aggregateId, @event, i));
            }
        }
    }

    public class AggregateNotFoundException : Exception
    {
    }

}
