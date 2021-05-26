namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services;
    using DotNetCenter.Beyond.Web.Core.Common;
    using DotNetCenter.Beyond.Web.Core.Controllers;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface SupportLoggingServices<TController>
        where TController : ProcessableEntry
    {
        public ILogger<TController> Logger { get; }
    }
}
