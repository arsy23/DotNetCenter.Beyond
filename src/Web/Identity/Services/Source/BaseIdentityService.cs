namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Core.ErrorHandlers;
    using DotNetCenter.Beyond.Web.Identity.Infrastructure.SqlServer;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Managers;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Models;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Extensions;

    public abstract  class BaseIdentityService<TKeyUser> 
        : IdentityService<TKeyUser> 
        where TKeyUser :  IEquatable<TKeyUser> 
    {

        protected readonly BaseAppUserManager<TKeyUser> _userManager;
        protected readonly CurrentUserService<TKeyUser> _currentUserService;
        public BaseIdentityService(BaseAppUserManager<TKeyUser> userManager, CurrentUserService<TKeyUser> currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public abstract Task<string> GetUserNameAsync(TKeyUser userId);
        //{
        //    if (!_currentUserService.IsUserAuthenticated)
        //        return "";

        //    var user = await _userManager.Users.FirstOrDefaultAsync(o => o.Id == userId);

        //    return user.UserName;
        //}
        public async Task<(ResultContainer Result, TKeyUser UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new AppUser<TKeyUser> { 
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            //return (result.ToApplicationResult(), user.Id);
            return (result.ToApplicationResult(), user.Id);
        }

        //public abstract Task<Result> DeleteUserAsync(Guid userId);
        //{
        //    var user = await _userManager.Users.FirstOrDefaultAsync(o => o.Id == userId);

        //    if (user != null)
        //    {
        //        return await DeleteUserAsync(user);
        //    }

        //    return ResultContainer.Success();
        //}

        public async Task<ResultContainer> DeleteUserAsync(AppUser<TKeyUser> user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public abstract Task<ResultContainer> DeleteUserAsync(TKeyUser userId);
    }
}
