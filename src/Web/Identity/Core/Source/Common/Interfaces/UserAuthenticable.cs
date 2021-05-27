using System.Security.Claims;
namespace DotNetCenter.Beyond.Web.Identity.Core
{
    public interface UserAuthenticable
    {
        bool isUserAthenticated(ClaimsPrincipal claimsPrincipal);
       string GenerateJwtForCurrentUser(string symmetricKey, string jwtAudience, string jwtIssuer);
       //string GenerateJwt(IdentityUser or Id,string username, string symmetricKey, string jwtAudience, string jwtIssuer);
    }
}