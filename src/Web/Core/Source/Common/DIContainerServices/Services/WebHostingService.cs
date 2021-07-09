namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    public class WebHostingService
        : SupportWebHosting
    {
        #region Constructor
        public WebHostingService(IWebHostEnvironmentServiceWrapper wrapper) 
            => _serviceWrapper = wrapper;
        #endregion
        public IWebHostEnvironmentServiceWrapper ServiceWrapper => _serviceWrapper;

        public IWebHostEnvironment Service => _serviceWrapper.Service;

        private readonly IWebHostEnvironmentServiceWrapper _serviceWrapper;
    }
}
