using Application.CreateProduct;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.ProductContext
{
    public class Product : AggregateRoot
    {
        public string Name { get; set; }
        public double Price { get; set; }


        private Product(Guid id, string name, double price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public static Product Create(string name, double price)
        {
            var product = new Product(Guid.NewGuid(), name, price);
            product.ApplyChange(new ProductCreatedEvent(name, price));

            return product;
        }
    }
}
