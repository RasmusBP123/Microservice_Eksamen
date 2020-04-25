using Domain;
using Domain.Core;
using Domain.Core.ProductContext;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IRepository<AggregateRoot> _repository;

        public CreateProductHandler(IRepository<AggregateRoot> repository)
        {
            _repository = repository;
        }

        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = Product.Create(request.Name, request.Price);
            _repository.Save(product, -1);

            return Task.FromResult(Unit.Value);
        }
    }
}
