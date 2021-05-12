namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using System;
    using System.Security.Claims;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using Microsoft.AspNetCore.Http;

    public abstract class BaseCurrentUserService
        : CurrentUserService
    {
        public BaseCurrentUserService(IHttpContextAccessor httpContextAccessor)
            => HttpContextAccessor = httpContextAccessor;
        public abstract IAppUser TryGetUser(out IAppUser user);
        protected bool TrySetUsername()
        {
            var userName = HttpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
                return false;
            UserName = userName;
            return true;
        }

        protected bool TrySetUserId()
        {
            var id = HttpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var isParsed = Guid.TryParse(id, out var userId);
            if (!isParsed)
            {
                UserId = Guid.Empty;
                return false;
            }
            else
            {
                UserId = userId;
                return true;
            }
        }

        public abstract bool TrySetUser();

        public Guid UserId { get; protected set; }
        public string UserName { get; protected set; }
        public bool IsUserAuthenticated { get => HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated;}
        public IHttpContextAccessor HttpContextAccessor { get; }
      
    }
}
