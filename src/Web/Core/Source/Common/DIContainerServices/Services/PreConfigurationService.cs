using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DotNetCenter.Beyond.Web.Core.Controllers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DotNetCenter.Beyond.Web.Core.Common;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    public class PreConfigurationService
            : SupportPreConfiguration
    {
        #region Constructor
        public PreConfigurationService(SupportConfiguration configuration,
                                       SupportWebHosting webHosting,
                                       SupportLoggerProviders loggerProviders)
        {
            _configuraion = configuration;
            _loggerProviders = loggerProviders;
            _webHosting = webHosting;
        }
        #endregion

        public SupportConfiguration Configuration => _configuraion;
        private readonly SupportConfiguration _configuraion;

        public SupportLoggerProviders LoggerProviders => _loggerProviders;
        private readonly SupportLoggerProviders _loggerProviders;

        public SupportWebHosting WebHosting => _webHosting;
        private readonly SupportWebHosting _webHosting;
    }
}
