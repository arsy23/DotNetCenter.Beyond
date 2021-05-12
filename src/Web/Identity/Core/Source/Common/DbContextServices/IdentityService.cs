namespace DotNetCenter.Beyond.Web.Identity.Core.DbContextServices
{
    using System;
    using System.Threading.Tasks;
    using DotNetCenter.Core.ErrorHandlers;
    public interface IdentityService 
    {
        Task<string> GetUserNameAsync(Guid userId);
        Task<(ResultContainer Result, Guid UserId)> CreateUserAsync(string userName, string password);
        Task<ResultContainer> DeleteUserAsync(Guid userId);
    }
}
