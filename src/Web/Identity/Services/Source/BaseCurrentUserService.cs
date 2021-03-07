﻿namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using System;
    using System.Security.Claims;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using Microsoft.AspNetCore.Http;

    public abstract  class BaseCurrentUserService<TKeyUser> 
        : CurrentUserService<TKeyUser> 
        where TKeyUser : IEquatable<TKeyUser>
    {
        public BaseCurrentUserService(IHttpContextAccessor httpContextAccessor) => HttpContextAccessor = httpContextAccessor;
        public bool TryGetUsername()
        {
            var userName = HttpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Name);
            if (string.IsNullOrEmpty(userName) || string.IsNullOrWhiteSpace(userName))
                return false;
            UserName = userName;
            return true;
        }

        public bool TryGetUserId()
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

        public Guid UserId { get; private set; }
        public string UserName { get; private set; }
        public bool IsUserAuthenticated { get => HttpContextAccessor.HttpContext.User.Identity.IsAuthenticated;}
        public IHttpContextAccessor HttpContextAccessor { get; }

        TKeyUser CurrentUserService<TKeyUser>.UserId { get; }
    }
}