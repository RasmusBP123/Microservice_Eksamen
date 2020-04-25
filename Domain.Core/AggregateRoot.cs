using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Domain.Core
{
    public abstract class AggregateRoot
    {
        private readonly List<IEvent> _changes = new List<IEvent>();
        public IReadOnlyList<IEvent> DomainEvents => _changes.ToList(); //Never expose the actual list for modification --- DDD
        public Guid Id { get; set;}
        public int Version { get; internal set; }

        protected AggregateRoot()
        {
        }

        public AggregateRoot(IEnumerable<IEvent> events)
        {
            if (events == null) return;

            foreach (var domainEvent in events)
            {
                Mutate(domainEvent);
                Version++;
            }
        }

        public void MarkChangesAsCommited()
        {
            _changes.Clear();
        }

        protected void ApplyChange(IEvent @event)
        {
            _changes.Add(@event);
        }


        private void Mutate(IEvent @event) =>
         ((dynamic)this).On((dynamic)@event);    
    }
}
