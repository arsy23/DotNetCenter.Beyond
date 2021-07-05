namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Core.Managers;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using DotNetCenter.Core.ErrorHandlers;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;

    public abstract class BaseIdentityService : IdentityService
    {

        protected readonly UserManagerService<IAppUser> _userManager;
        protected readonly CurrentUserService _currentUserService;
        public BaseIdentityService(UserManagerService<IAppUser> userManager,
            CurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public virtual async Task<string> GetUsernameAsync(Guid userId)
        {
            if (!_currentUserService.IsUserAuthenticated)
                return "";

            var user = await _userManager.Users.FirstOrDefaultAsync(o => o.Id == userId);

            return user.Username;
        }
        public virtual async Task<ResultContainer> DeleteUserAsync(IAppUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
        public virtual async Task<ResultContainer> DeleteUserAsync(Guid userId)
        {
            IAppUser user = await GetUserFormUserManagerAsync(userId);

            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
        private async Task<IAppUser> GetUserFormUserManagerAsync(Guid userId)
        {
            return await _userManager.Users.FirstAsync(o => o.Id.CompareTo(userId) == 0);
        }
        public virtual async Task<ResultContainer> DeleteCurrentUserAsync()
        {
            if (!_currentUserService.IsUserAuthenticated)
                return new ResultContainer(false, new[] { "" });

            var user = await GetUserFormUserManagerAsync(_currentUserService.UserId);
            var result = await _userManager.DeleteAsync(user);
            return result.ToApplicationResult();
        }

        public async Task<(ResultContainer Result, Guid UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new AppUser(Guid.NewGuid(), DateTime.UtcNow)
            {
                Username = userName,
            };

            var result = await _userManager.CreateAsync(user);

            return (result.ToApplicationResult(), user.Id);
        }
    }
}
