namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    public class WebHostingService
        : SupportWebHosting
    {
        #region Constructor
        public WebHostingService(IWebHostEnvironment webHostEnvService) 
            => _webHostEnvService = webHostEnvService;
        #endregion
        public IWebHostEnvironment WebHostEnvService => _webHostEnvService;
        private readonly IWebHostEnvironment _webHostEnvService;

        public string WebEnvironmentName
            => _webHostEnvService.EnvironmentName;
    }
}
