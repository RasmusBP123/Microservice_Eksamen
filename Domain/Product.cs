using Application.CreateProduct;
using Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Product : AggregateRoot
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(){}

        private Product(string name, double price)
        {
            Name = name;
            Price = price;
        }

        public static Product Create(string name, double price)
        {
            var product = new Product(name, price);
            product.ApplyChange(new ProductCreatedEvent(name, price));

            return product;
        }
    }
}
