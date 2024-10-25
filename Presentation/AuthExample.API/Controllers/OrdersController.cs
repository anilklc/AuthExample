using AuthExample.Application.Features.Commands.Order.CreateOrder;
using AuthExample.Application.Features.Commands.Order.UpdateOrder;
using AuthExample.Application.Features.Queries.Order.GetAllOrder;
using AuthExample.Application.Features.Queries.Order.GetByUsernameOrder;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllOrders()
        {
            GetAllOrderQueryResponse response = await _mediator.Send(new GetAllOrderQueryRequest());
            return Ok(response);

        }
        [HttpGet("[action]/{Username}")]
        public async Task<IActionResult> GetByUsernameOrder([FromRoute] GetByUsernameOrderQueryRequest request)
        {
            GetByUsernameOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommandRequest request)
        {
            UpdateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
