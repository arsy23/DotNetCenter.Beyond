namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using System;
    using System.Threading.Tasks;
    using DotNetCenter.Core.ErrorHandlers;
    public interface IdentityService<TKeyUser> 
        where TKeyUser : IEquatable<TKeyUser>
    {
        Task<string> GetUserNameAsync(TKeyUser userId);
        Task<(ResultContainer Result, TKeyUser UserId)> CreateUserAsync(string userName, string password);
        Task<ResultContainer> DeleteUserAsync(TKeyUser userId);
    }
}
