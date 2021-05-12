namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using System;
    public interface CurrentUserService
    {
        bool TrySetUser();
        Guid UserId { get; }
        string UserName { get; }
        public bool IsUserAuthenticated { get; }
    }
}
