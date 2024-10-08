using AuthExample.Application.DTOs.Token;

namespace AuthExample.Application.Features.Commands.User.RefreshTokenLogin
{
    public class RefreshTokenLoginCommandResponse
    {
        public Token Token { get; set; }
    }
}