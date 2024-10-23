using AuthExample.Application.CustomAttributes;
using AuthExample.Application.Enums;
using AuthExample.Application.Features.Commands.User.AssignRoleToUser;
using AuthExample.Application.Features.Commands.User.CreateUser;
using AuthExample.Application.Features.Commands.User.Remove;
using AuthExample.Application.Features.Commands.User.UpdatePassword;
using AuthExample.Application.Features.Queries.User.GetAllUser;
using AuthExample.Application.Features.Queries.User.GetRolesToUser;
using AuthExample.Application.Features.Queries.User.GetUserByUserId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthExample.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllUsers()
        {
            GetAllUsersQueryResponse response = await _mediator.Send(new GetAllUsersQueryRequest());
            return Ok(response);
        }

        [HttpGet("[action]/{UserId}")]
        public async Task<IActionResult> GetUserByUserId([FromRoute] GetUserByUserIdQueryRequest request)
        {
            GetUserByUserIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}/{AuthorizedRole}/{Authorized}")]
        public async Task<IActionResult> RemoveUser([FromRoute] RemoveUserCommandRequest request)
        {
            RemoveUserCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AssignRoleToUser(AssignRoleToUserCommandRequest assignRoleToUserCommandRequest)
        {
            AssignRoleToUserCommandResponse response = await _mediator.Send(assignRoleToUserCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]/{UserId}")]
        public async Task<IActionResult> GetRolesToUser([FromRoute] GetRolesToUserQueryRequest getRolesToUserQueryRequest)
        {
            GetRolesToUserQueryResponse response = await _mediator.Send(getRolesToUserQueryRequest);
            return Ok(response);
        }
    }
}
