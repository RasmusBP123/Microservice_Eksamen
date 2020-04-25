using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public class Repository<T> : IRepository<T> where T : AggregateRoot, new()
    {

        public T GetById(Guid aggregateId)
        {
            throw new NotImplementedException();
        }

        public void Save(AggregateRoot aggregateRoot, int expectedVersion)
        {
            throw new NotImplementedException();
        }
    }
}
