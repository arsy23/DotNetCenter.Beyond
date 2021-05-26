using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
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
    public class LoggingService<TController>
        : SupportLoggingServices<TController>
        where TController : ProcessableEntry
    {
        #region Constructor
        public LoggingService(ILogger<TController> logger) => _logger = logger;
        #endregion

        public ILogger<TController> Logger => _logger;
        private readonly ILogger<TController> _logger;
    }
}
