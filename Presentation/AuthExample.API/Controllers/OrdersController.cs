using AuthExample.Application.Consts;
using AuthExample.Application.CustomAttributes;
using AuthExample.Application.Enums;
using AuthExample.Application.Features.Commands.Order.CreateOrder;
using AuthExample.Application.Features.Commands.Order.UpdateOrder;
using AuthExample.Application.Features.Queries.Order.GetAllOrder;
using AuthExample.Application.Features.Queries.Order.GetByIdOrder;
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
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Orders, ActionType = ActionType.Reading, Definition = "Get All Orders")]
        public async Task<IActionResult> GetAllOrders()
        {
            GetAllOrderQueryResponse response = await _mediator.Send(new GetAllOrderQueryRequest());
            return Ok(response);

        }

        [HttpGet("[action]/{Username}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.Reading, Definition = "Get By Username Order (User)")]
        public async Task<IActionResult> GetByUsernameOrder([FromRoute] GetByUsernameOrderQueryRequest request)
        {
            GetByUsernameOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.Reading, Definition = "Get By Id Order")]
        public async Task<IActionResult> GetByIdOrder([FromRoute] GetByIdOrderQueryRequest request)
        {
            GetByIdOrderQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.Writing, Definition = "Create Order (User)")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommandRequest request)
        {
            CreateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.User, ActionType = ActionType.Writing, Definition = "Update Order (User)")]
        public async Task<IActionResult> UpdateOrder([FromBody] UpdateOrderCommandRequest request)
        {
            UpdateOrderCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
