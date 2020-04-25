using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CreateProduct
{
    public class ProductCreatedEvent : IEvent
    {
        public ProductCreatedEvent(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public double Price { get; }
    }
}
