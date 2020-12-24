using System.Collections.Generic;
using System.Security.Claims;

namespace Metropolis.API
{
    public interface ITokenService
    {
        string GenerateAccessToken();
        string GenerateRefreshToken();
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
       
    }
}