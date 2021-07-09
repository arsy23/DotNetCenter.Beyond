namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    public class WebHostingServiceWrapper : IWebHostEnvironmentServiceWrapper
    {
        #region Constructor
        public WebHostingServiceWrapper(IWebHostEnvironment webHostEnvService) 
            => _webHostEnvService = webHostEnvService;
        #endregion
        public IWebHostEnvironment Service => _webHostEnvService;
        private readonly IWebHostEnvironment _webHostEnvService;
    }
}
