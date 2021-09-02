namespace DotNetCenter.Beyond.Web.Identity.Services.Managers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public interface CurrentUserService
    {
        int? UserId { get; }
        string Username { get; }
        public bool IsUserAuthenticated();
        public Task<bool> IsUserAuthenticated(CancellationToken cancellationToken);
    }
}
