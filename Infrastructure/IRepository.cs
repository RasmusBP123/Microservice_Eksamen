using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IRepository<T> where T : AggregateRoot, new()
    {
        void Save(AggregateRoot aggregateRoot, int expectedVersion);
        T GetById(Guid aggregateId);
    }
}
