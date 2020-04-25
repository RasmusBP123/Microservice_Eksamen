using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CreateProduct;
using Application.GetAllProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost()]
        public IActionResult CreatePost()
        {
            _mediator.Send(new CreateProductCommand("Små sko", 1000));
            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetPosts()
        {
            var result = _mediator.Send(new GetAllProductsQuery());
            return Ok();
        }
    }
}