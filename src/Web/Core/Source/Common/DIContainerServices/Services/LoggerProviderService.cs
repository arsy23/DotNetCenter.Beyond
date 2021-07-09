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
    public class LoggerProviderService
            : SupportLoggerProviders
    {
        #region Constructor
        public LoggerProviderService(ILoggerFactory factory)
            => _factory = factory;
        #endregion

        public ILoggerFactory Factory => _factory;
        private readonly ILoggerFactory _factory;
    }
}
