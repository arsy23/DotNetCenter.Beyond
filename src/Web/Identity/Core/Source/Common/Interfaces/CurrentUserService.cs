namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using System;
    public interface CurrentUserService
    {
        bool TrySetUsername();
        bool TrySetUserId();
        Guid UserId { get; }
        string Username { get; }
        public bool IsUserAuthenticated { get; }
    }
}
