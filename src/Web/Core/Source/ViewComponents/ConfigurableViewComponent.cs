namespace DotNetCenter.Beyond.Web.Core.ViewComponents
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Configuration;
    public abstract class ConfigurableViewComponent : ViewComponent
    {
        private IConfiguration _configuration;
        protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
    }
}
