namespace DotNetCenter.Beyond.Web.Projects.Configuration.Core.Interfaces
{
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public interface SupportConfigurationManager : ConfigurationManager
    {
        SupportJsonConfigurationManager JsonConfigurationManagerService { get; }
        //void AddJsonConfiguration(
        //    ref IServiceCollection services
        //    , string fileName
        //    , string configurationBasePath
        //    , string[] args);
    }
}
