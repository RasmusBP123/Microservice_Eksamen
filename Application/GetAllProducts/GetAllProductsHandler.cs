using Domain;
using Domain.Core;
using Domain.Core.ProductContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Product>>
    {
        private readonly Domain.Core.IRepository<AggregateRoot> _repository;

        public GetAllProductsHandler(IRepository<AggregateRoot> repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {

            return;
        }
    }
}
