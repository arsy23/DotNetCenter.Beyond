namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Core.Managers;
    using DotNetCenter.Beyond.Web.Identity.Core.Models;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using DotNetCenter.Core.ExceptionHandlers;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    public abstract class UserAuthenticationService : UserAuthenticable
    {
        private readonly IdentityDbService _context;
        private readonly CurrentUserService _currentUserService;
        private readonly UserManagerService<IAppUser> _userManager;
        private readonly SignInManagerService<IAppUser> _signInManager;

        public IdentityService IdentityService => _identityService;
        private readonly IdentityService _identityService;
        public UserAuthenticationService(
            IdentityDbService context,
            IdentityService identityService,
            CurrentUserService currentUserService,
            UserManagerService<IAppUser> userManager,
            SignInManagerService<IAppUser> signInManager)
        {
            _context = context;
            _identityService = identityService;
            _userManager = userManager;
            _signInManager = signInManager;
            _currentUserService = currentUserService;
        }

        public string GenerateJwtForCurrentUser(
            string symmetricKey,
            string jwtAudience,
            string jwtIssuer,
            double expirationFromNow)
        {

            if (!_currentUserService.TrySetUserId())
                throw new NotFoundException("IdentityUser UserId not found!");

            if (!_currentUserService.TrySetUsername())
                throw new NotFoundException("IdentityUser Username not found!");

            var claims = new List<Claim>
        {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, _currentUserService.Username),
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, _currentUserService.UserId.ToString())
        };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(symmetricKey));

            var creds = new SigningCredentials(
                key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(expirationFromNow);

            var token = new JwtSecurityToken(
                jwtIssuer,
                jwtAudience,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool isUserAthenticated(ClaimsPrincipal claimsPrincipal)
            => _signInManager.IsSignedIn(claimsPrincipal);

        public abstract string GenerateJwtForCurrentUser(string symmetricKey, string jwtAudience, string jwtIssuer);

    }
}
