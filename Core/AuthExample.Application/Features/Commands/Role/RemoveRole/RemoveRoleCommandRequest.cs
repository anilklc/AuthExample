using MediatR;

namespace AuthExample.Application.Features.Commands.Role.RemoveRole
{
    public class RemoveRoleCommandRequest : IRequest<RemoveRoleCommandResponse>
    {
        public string Id { get; set; }
    }
}