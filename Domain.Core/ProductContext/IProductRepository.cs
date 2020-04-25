using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Core.ProductContext
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
    }
}
