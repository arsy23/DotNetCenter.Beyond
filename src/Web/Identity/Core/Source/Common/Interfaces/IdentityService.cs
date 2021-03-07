namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using System;
    using System.Threading.Tasks;
    using DotNetCenter.Core.ErrorHandlers;
    public interface IdentityService<TAppKey> 
        where TAppKey : IEquatable<TAppKey>
    {
        Task<string> GetUserNameAsync(TAppKey userId);
        Task<(ResultContainer Result, TAppKey UserId)> CreateUserAsync(string userName, string password);
        Task<ResultContainer> DeleteUserAsync(TAppKey userId);
    }
}
