namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using System;
    public interface CurrentUserService<TKeyUser> 
        where TKeyUser : IEquatable<TKeyUser>
    {
        TKeyUser UserId { get; }
        string UserName { get; }
        public bool IsUserAuthenticated { get; }
        bool TryGetUsername();
        bool TryGetUserId();
    }
}
