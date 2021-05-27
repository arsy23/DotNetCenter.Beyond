using DotNetCenter.Beyond.Web.Identity.Core.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.Web.Identity.Core.Managers
{
    public interface SignInManagerService : SignInManagerService<IAppUser>
    {
    }
    public interface SignInManagerService<TAppUser>
        where TAppUser : IAppUser
    {
        #region IsSignedIn
        //
        // Summary:
        //     Returns true if the principal has an identity with the application cookie identity
        //
        // Parameters:
        //   principal:
        //     The System.Security.Claims.ClaimsPrincipal instance.
        //
        // Returns:
        //     True if the user is logged in with identity.
        public bool IsSignedIn(ClaimsPrincipal principal);
        #endregion
       
    }
}
