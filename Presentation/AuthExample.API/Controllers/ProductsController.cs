using AuthExample.Application.Features.Commands.Product.CreateProduct;
using AuthExample.Application.Features.Commands.Product.RemoveProduct;
using AuthExample.Application.Features.Commands.Product.UpdateProduct;
using AuthExample.Application.Features.Queries.Product.GetAllProduct;
using AuthExample.Application.Features.Queries.Product.GetByIdProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllProducts()
        {
            GetAllProductQueryResponse response = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(response);

        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> GetByIdProduct([FromRoute] GetByIdProductQueryRequest request)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateProduct([FromForm] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> RemoveProduct(string Id)
        {
            RemoveProductCommandRequest request = new RemoveProductCommandRequest { Id = Id };
            RemoveProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
