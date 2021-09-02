
namespace DotNetCenter.Beyond.Mediation.Behaviours
{
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using System;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using DotNetCenter.Beyond.Web.Identity.Services;
    using DotNetCenter.Beyond.Web.Identity.Services.Managers;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;

    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly CurrentUserService _currentUserService;
        private readonly IdentityService<IIdentityUser> _identityService;

        public RequestLogger(
            ILogger<TRequest> logger,
            CurrentUserService currentUserService,
            IdentityService<IIdentityUser> identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            int? userId = -9845;
            var userName = "Not Authorized User";
            if (_currentUserService.IsUserAuthenticated())
            {
                userId = _currentUserService.UserId;
                userName = await _identityService.GetUsernameAsync((int)_currentUserService.UserId);
            }
            _logger.LogInformation("Request: {Name} {@UserId} {@UserName} {@Request}", typeof(TRequest).Name, userId, userName, request);
        }
    }
}
