using DotNetCenter.Beyond.Web.Identity.Core.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.Web.Identity.Core.Managers
{
    public interface UserManagerService : UserManagerService<IAppUser>
    {
    }
    public interface UserManagerService<TAppUser>
        where TAppUser : IAppUser
    {
        #region CreateAsync
        public Task<IdentityResult> CreateAsync(TAppUser user);
        public Task<IdentityResult> CreateAsync(TAppUser user, string password);
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
        public Task<IdentityResult> DeleteAsync(TAppUser user);
        #endregion
        #region Users
        //
        // Summary:
        //     Returns an IQueryable of users if the store is an IQueryableUserStore
        public virtual IQueryable<TAppUser> Users
        {
            get
            {
                throw null;
            }
        }
        #endregion
        #region GetUserAsync
        public Task<TAppUser> GetUserAsync(ClaimsPrincipal principal);
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
        public Task<string> GetSecurityStampAsync(TAppUser user);
        #endregion
    }
}
