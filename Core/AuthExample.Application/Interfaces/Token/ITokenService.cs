using AuthExample.Application.DTOs.Token;
using AuthExample.Domain.Entities.Identity;

namespace AuthExample.Application.Interfaces
{
    public interface ITokenService
    {
        Token CreateToken(AppUser user);
        string GenerateRefreshToken();
    }
}
