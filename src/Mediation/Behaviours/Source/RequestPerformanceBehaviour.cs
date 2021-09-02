namespace DotNetCenter.Beyond.Mediation.Behaviours
{
    using Microsoft.Extensions.Logging;
    using System.Diagnostics;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using MediatR;
    using System;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;
    using DotNetCenter.Beyond.Web.Identity.Services.Managers;
    using System.Security.Principal;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
    using DotNetCenter.Beyond.Web.Identity.Services;

    public class RequestPerfObjRelMappinganceBehaviour<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;
        private readonly CurrentUserService _currentUserService;
        private readonly IdentityService<IIdentityUser> _identityService;

        public RequestPerfObjRelMappinganceBehaviour(
            ILogger<TRequest> logger,
            CurrentUserService currentUserService,
            IdentityService<IIdentityUser> identityService)
        {
            _timer = new Stopwatch();
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();
            var response = await next();
            _timer.Stop();
            await LogRequest(request);
            return response;
        }

        private async Task LogRequest(TRequest request)
        {
            if (_timer.ElapsedMilliseconds > 500)
                await LogRequestLongRunning(request);
        }

        private async Task LogRequestLongRunning(TRequest request)
        {
            var logMessage = "Application Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId}";
            var requestName = typeof(TRequest).Name;
            //if (_currentUserService.TrySetUserId())
                await LogCriticalWithUserName(request, _timer.ElapsedMilliseconds, logMessage, requestName);
            //else
            //    _logger.LogCritical(logMessage + "{@Request}", requestName, _timer.ElapsedMilliseconds, request);
        }

        private async Task LogCriticalWithUserName(TRequest request, long elapsedMilliseconds, string logMessage, string requestName)
        {
            var userId = _currentUserService.UserId;
             var username = _currentUserService?.Username ?? "UnAuthorized User %!%";
            _logger.LogCritical(logMessage + "{@UserName} {@Request}", requestName, elapsedMilliseconds, userId, username, request);
        }
    }
}
