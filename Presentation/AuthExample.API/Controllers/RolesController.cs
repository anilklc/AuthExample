using AuthExample.Application.Consts;
using AuthExample.Application.CustomAttributes;
using AuthExample.Application.Enums;
using AuthExample.Application.Features.Commands.Role.CreateRole;
using AuthExample.Application.Features.Commands.Role.RemoveRole;
using AuthExample.Application.Features.Commands.Role.UpdateRole;
using AuthExample.Application.Features.Queries.Role.GetAllRole;
using AuthExample.Application.Features.Queries.Role.GetRoleById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
      
        readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Reading, Definition = "Get Roles")]
        public async Task<IActionResult> GetAllRole([FromQuery] GetAllRoleQueryRequest getAllRoleQueryRequest)
        {
            GetAllRoleQueryResponse response = await _mediator.Send(getAllRoleQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Reading, Definition = "Get Role By Id")]
        public async Task<IActionResult> GetRoles([FromRoute] GetRoleByIdQueryRequest getRoleByIdQueryRequest)
        {
            GetRoleByIdQueryResponse response = await _mediator.Send(getRoleByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost()]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Writing, Definition = "Create Role")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommandRequest createRoleCommandRequest)
        {
            CreateRoleCommandResponse response = await _mediator.Send(createRoleCommandRequest);
            return Ok(response);
        }

        [HttpPut("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Updating, Definition = "Update Role")]
        public async Task<IActionResult> UpdateRole([FromBody, FromRoute] UpdateRoleCommandRequest updateRoleCommandRequest)
        {
            UpdateRoleCommandResponse response = await _mediator.Send(updateRoleCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitionConstants.Roles, ActionType = ActionType.Deleting, Definition = "Delete Role")]
        public async Task<IActionResult> DeleteRole([FromRoute] RemoveRoleCommandRequest removeRoleCommandRequest)
        {
            RemoveRoleCommandResponse response = await _mediator.Send(removeRoleCommandRequest);
            return Ok(response);
        }

    }
}
