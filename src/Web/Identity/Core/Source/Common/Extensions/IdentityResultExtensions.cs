namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Extensions
{
    using System.Linq;
    using DotNetCenter.Core.ErrorHandlers;
    using Microsoft.AspNetCore.Identity;

    public static class IdentityResultExtensions
    {
        public static ResultContainer ToApplicationResult(this IdentityResult result)
        {
            return result.Succeeded
                ? ResultContainer.Success()
                : ResultContainer.Failure(result.Errors.Select(e => e.Description));
        }
    }
}