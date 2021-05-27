
namespace DotNetCenter.Beyond.Mediation.Behaviours
{
    using MediatR.Pipeline;
    using Microsoft.Extensions.Logging;
    using System.Threading;
    using System.Threading.Tasks;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using System;
    using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices;

    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;
        private readonly CurrentUserService _currentUserService;
        private readonly IdentityService _identityService;

        public RequestLogger(
            ILogger<TRequest> logger,
            CurrentUserService currentUserService,
            IdentityService identityService)
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
