namespace DotNetCenter.Beyond.Web.Identity.Core
{
    using System;
    public interface CurrentUserService<TAppKey> 
        where TAppKey : IEquatable<TAppKey>
    {
        TAppKey UserId { get; }
        string UserName { get; }
        public bool IsUserAuthenticated { get; }
        bool TryGetUsername();
        bool TryGetUserId();
    }
}
