namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using DotNetCenter.Beyond.Web.Identity.Core.Managers;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections;
    using System.Security.Claims;
    using System.Threading;
    using System.Threading.Tasks;
    public class RevalidatingIdentityAuthenticationStateProvider<TAppUser, TKeyUser> 
        : RevalidatingServerAuthenticationStateProvider 
        //dc#1# developer: development cases
        //Case 2 : For SwitchContects internal 
        where TAppUser : AppUser
        //Case 1 : For SwitchContects of Code To Generic Types 
        //where TAppUser : class, IAppUser
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IdentityOptions _options;
        public RevalidatingIdentityAuthenticationStateProvider(ILoggerFactory loggerFactory,
                                                               UserManagerService<IAppUser> userManagerService,
                                                               IServiceScopeFactory scopeFactory,
                                                               IOptions<IdentityOptions> optionsAccessor)
            : base(loggerFactory)
        {
            _userManager = userManagerService;
            _scopeFactory = scopeFactory;
            _options = optionsAccessor.Value;
        }

        private  readonly UserManagerService<IAppUser> _userManager;
        protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(30);
        protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState,
                                                                             CancellationToken cancellationToken)
        {
            // Get the user manager from a new scope to ensure it fetches fresh data
            var scope = _scopeFactory.CreateScope();
            try
            {
                return await ValidateSecurityStampAsync(authenticationState.User);
            }
            finally
            {
                if (scope is IAsyncDisposable asyncDisposable)
                    await asyncDisposable.DisposeAsync();
                else
                    scope.Dispose();
            }
        }
        private async Task<bool> ValidateSecurityStampAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            if (user == null)
                return false;
            else if (!_userManager.SupportsUserSecurityStamp)
                return true;
            else
            {
                var principalStamp = principal.FindFirstValue(_options.ClaimsIdentity.SecurityStampClaimType);
                var userStamp = await _userManager.GetSecurityStampAsync(user);
                return principalStamp == userStamp;
            }
        }
    }
}
