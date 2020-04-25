using System;

namespace Domain.Core
{
    public interface IEvent
    {
    }

    public class Event : IEvent
    {
        public Guid Id { get; set; }
        public int Version { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Name { get; set; }
        public Guid AggregateRootId { get; set; }
    }
}