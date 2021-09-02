namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using System;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
    using DotNetCenter.Core.ErrorHandlers;
    public interface IdentityService<TAppUser>
       where TAppUser : IIdentityUser
    {
        Task<string> GetUsernameAsync(int userId);
        Task<(ResultContainer Result, int UserId)> CreateUserAsync(TAppUser user);
        Task<ResultContainer> DeleteUserAsync(int userId);
    }
}
