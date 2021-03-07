namespace DotNetCenter.Beyond.Web.Core.Presenters
{

    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    public abstract  class ConfigurablePresenter
    {
        public IHttpContextAccessor HttpContextAccessor { get; set; }
        public ConfigurablePresenter(IHttpContextAccessor context)
            => HttpContextAccessor = context;
        private IConfiguration _configuration;
        protected IConfiguration Configuration => _configuration ??= HttpContextAccessor.HttpContext.RequestServices.GetService<IConfiguration>();
    }

}
