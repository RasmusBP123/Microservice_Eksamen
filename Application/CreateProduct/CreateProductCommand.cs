using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CreateProduct
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductCommand(string name, float price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; }
        public float Price { get; }
    }
}
