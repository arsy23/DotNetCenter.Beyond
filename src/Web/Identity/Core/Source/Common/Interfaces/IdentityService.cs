namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using System;
    using System.Threading.Tasks;
    using DotNetCenter.Core.ErrorHandlers;
    public interface IdentityService 
    {
        Task<string> GetUsernameAsync(Guid userId);
        Task<(ResultContainer Result, Guid UserId)> CreateUserAsync(string userName, string password);
        Task<ResultContainer> DeleteUserAsync(Guid userId);
    }
}
