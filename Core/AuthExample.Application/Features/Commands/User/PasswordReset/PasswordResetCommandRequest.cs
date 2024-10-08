using MediatR;

namespace AuthExample.Application.Features.Commands.User.PasswordReset
{
    public class PasswordResetCommandRequest : IRequest<PasswordResetCommandResponse>
    {
        public string Email { get; set; }
    }
}