namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Core.Common.Managers;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using DotNetCenter.Core.ErrorHandlers;
    using System;
    using System.Threading.Tasks;

    public abstract class BaseIdentityService : IdentityService
    {

        protected readonly BaseAppUserManager _userManager;
        protected readonly CurrentUserService _currentUserService;
        public BaseIdentityService(BaseAppUserManager userManager, CurrentUserService currentUserService)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
        }

        public abstract Task<string> GetUserNameAsync(Guid userId);
        //{
        //    if (!_currentUserService.IsUserAuthenticated)
        //        return "";

        //    var user = await _userManager.Users.FirstOrDefaultAsync(o => o.Id == userId);

        //    return user.UserName;
        //}
        public async Task<(ResultContainer Result, Guid UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new AppUser(Guid.NewGuid(), DateTime.UtcNow)
            {
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

        public async Task<ResultContainer> DeleteUserAsync(IAppUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        public abstract Task<ResultContainer> DeleteUserAsync(Guid userId);
    }
}
