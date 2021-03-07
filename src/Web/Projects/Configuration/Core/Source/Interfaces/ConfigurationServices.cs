namespace DotNetCenter.Beyond.Web.Projects.Configuration.Core
{
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using DotNetCenter.Beyond.Web.Projects.Configuration.Core.Interfaces;
    using Microsoft.Extensions.Configuration;
    using System;
    using System.Collections.Generic;
    using System.Text; 
    public interface ConfigurationServices
    {
        SupportConfiguration ConfigurationService { get; }
        SupportWebHosting WebHostingService { get; }
    }
}
