using Domain;
using Domain.Core.ProductContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.GetAllProducts
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
