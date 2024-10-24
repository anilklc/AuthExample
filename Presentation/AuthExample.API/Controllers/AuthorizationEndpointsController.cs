using AuthExample.Application.Consts;
using AuthExample.Application.CustomAttributes;
using AuthExample.Application.Enums;
using AuthExample.Application.Features.Commands.AuthorizationEndpoint.AssignRoleEndpoint;
using AuthExample.Application.Features.Queries.AuthorizationEndpoint.GetRolesToEndpoint;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationEndpointsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorizationEndpointsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]/{Menu}/{Code}")]
        public async Task<IActionResult> GetRolesToEndpoint([FromRoute] GetRolesToEndpointQueryRequest rolesToEndpointQueryRequest)
        {
            GetRolesToEndpointQueryResponse response = await _mediator.Send(rolesToEndpointQueryRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.AuthorizationEndpoint, ActionType = ActionType.Writing, Definition = "Assign Role")]
        public async Task<IActionResult> AssignRoleEndpoint(AssignRoleEndpointCommandRequest assignRoleEndpointCommandRequest)
        {
            assignRoleEndpointCommandRequest.Type = typeof(Program);
            AssignRoleEndpointCommandResponse response = await _mediator.Send(assignRoleEndpointCommandRequest);
            return Ok(response);
        }
    }
}
