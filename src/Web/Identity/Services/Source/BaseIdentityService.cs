namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
    using DotNetCenter.Beyond.Web.Identity.Services.Managers;
    using DotNetCenter.Core.ErrorHandlers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public abstract class BaseIdentityService<TUserManagerService, TCurrentUserService, TAppUser>: IdentityService<TAppUser>
        where TUserManagerService : UserManagerService<TAppUser>
        where TCurrentUserService : CurrentUserService
        where TAppUser : IIdentityUser
    {

        protected readonly TUserManagerService _userManager;
        protected readonly TCurrentUserService _currentUserService;
        public BaseIdentityService(TUserManagerService userManager,
            TCurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public virtual async Task<string> GetUsernameAsync(int userId)
        {
            if (!_currentUserService.IsUserAuthenticated())
                return "";

            var user = await _userManager.Users.FirstOrDefaultAsync(o => o.Id == userId);

            return user.UserName;
        }
        public virtual async Task<ResultContainer> DeleteUserAsync(TAppUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
        public virtual async Task<ResultContainer> DeleteUserAsync(int userId)
        {
            TAppUser user = await GetUserFormUserManagerAsync(userId);

            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
        private async Task<TAppUser> GetUserFormUserManagerAsync(int? userId)
        {
            return await _userManager.Users?.FirstAsync(o => o.Id == userId);
        }
        public virtual async Task<ResultContainer> DeleteCurrentUserAsync()
        {
            if (!_currentUserService.IsUserAuthenticated())
                return new ResultContainer(false, new[] { "" });

            var user = await GetUserFormUserManagerAsync(_currentUserService.UserId);
            var result = await _userManager.DeleteAsync(user);
            return result.ToApplicationResult();
        }
        public abstract  Task<(ResultContainer Result, int UserId)> CreateUserAsync(TAppUser user);
    }
}
