
namespace DotNetCenter.Beyond.Mediation.Behaviours
{
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using System;

    public class RequestLogger<TRequest, TAppKey> : IRequestPreProcessor<TRequest>
        where TAppKey : IEquatable<TAppKey>
    {
        private readonly ILogger _logger;
        private readonly CurrentUserService<TAppKey> _currentUserService;
        private readonly IdentityService<TAppKey> _identityService;

        public RequestLogger(
            ILogger<TRequest> logger,
            CurrentUserService<TAppKey> currentUserService,
            IdentityService<TAppKey> identityService)
        {
            _logger = logger;
            _currentUserService = currentUserService;
            _identityService = identityService;
        }
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var userName = await _identityService.GetUserNameAsync(_currentUserService.UserId);
            _logger.LogInformation("Request: {Name} {@UserId} {@UserName} {@Request}", typeof(TRequest).Name, _currentUserService.UserId, userName, request);
        }
    }
}
