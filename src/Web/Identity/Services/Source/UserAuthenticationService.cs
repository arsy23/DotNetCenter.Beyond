﻿namespace DotNetCenter.Beyond.Web.Identity.Services
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using Microsoft.IdentityModel.JsonWebTokens;
    using DotNetCenter.Core.ExceptionHandlers;

    public abstract  class UserAuthenticationService<TKeyUser> : UserAuthenticable
        where TKeyUser : IEquatable<TKeyUser>
    {
        private readonly IdentityDbService _context;
        private readonly CurrentUserService<TKeyUser> _currentUserService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public BaseIdentityService<TKeyUser> IdentityService { get; set; }
        public UserAuthenticationService(
            IdentityDbService context,
            BaseIdentityService<TKeyUser> identityService,
            CurrentUserService<TKeyUser> currentUserService,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _context = context;
            IdentityService = identityService;
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
           var gettinUserIdSucceded =  _currentUserService.TryGetUserId();
           var gettinUsernameSucceded = _currentUserService.TryGetUsername();

            if (!gettinUserIdSucceded)
                throw new NotFoundException("IdentityUser UserId not found!");

            else if (!gettinUsernameSucceded)
                throw new NotFoundException("IdentityUser Username not found");

        var claims = new List<Claim>
        {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, _currentUserService.UserName),
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