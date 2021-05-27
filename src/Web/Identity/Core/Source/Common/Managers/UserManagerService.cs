using DotNetCenter.Beyond.Web.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.Web.Identity.Core.Managers
{
    public interface UserManagerService
    {
        #region CreateAsync
        public Task<IdentityResult> CreateAsync(IAppUser user);
        public Task<IdentityResult> CreateAsync(IAppUser user, string password);
        #endregion
        #region DeleteAsync
        //
        // Summary:
        //     Deletes the specified user from the backing store.
        //
        // Parameters:
        //   user:
        //     The user to delete.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the Microsoft.AspNetCore.Identity.IdentityResult of the operation.
        public Task<IdentityResult> DeleteAsync(IAppUser user);
        #endregion
        #region Users
        //
        // Summary:
        //     Returns an IQueryable of users if the store is an IQueryableUserStore
        public virtual IQueryable<IAppUser> Users
        {
            get
            {
                throw null;
            }
        }
        #endregion
        #region GetUserAsync
        public Task<IAppUser> GetUserAsync(ClaimsPrincipal principal);
        #endregion
        #region SupportsUserSecurityStamp
        //
        // Summary:
        //     Gets a flag indicating whether the backing user store supports security stamps.
        //
        // Value:
        //     true if the backing user store supports user security stamps, otherwise false.
        public bool SupportsUserSecurityStamp { get; }
        #endregion
        #region GetSecurityStampAsync
        //
        // Summary:
        //     Get the security stamp for the specified user.
        //
        // Parameters:
        //   user:
        //     The user whose security stamp should be set.
        //
        // Returns:
        //     The System.Threading.Tasks.Task that represents the asynchronous operation, containing
        //     the security stamp for the specified user.
        public Task<string> GetSecurityStampAsync(IAppUser user);
        #endregion
    }
}
