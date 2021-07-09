namespace DotNetCenter.Beyond.Web.Projects.Configuration.Core.Services
{
    
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Primitives;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
    using Microsoft.AspNetCore.Http;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices;

    public abstract  class BaseConfigService 
        : ConfigurationServices
    {
        public BaseConfigService(
            SupportConfiguration configurationService,
            SupportWebHosting webHostingService)
        {
            _configurationService = configurationService;
            _webHostingService = webHostingService;
        }
        #region Properties
        public SupportConfiguration ConfigurationService => _configurationService;
        private SupportConfiguration _configurationService;
        
        public SupportWebHosting WebHostingService => _webHostingService;
                private SupportWebHosting _webHostingService;
        #endregion


    }
}
