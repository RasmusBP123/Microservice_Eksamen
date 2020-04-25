using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Customer : AggregateRoot
    {
        public string Fulllname { get; set; }
    }
}
