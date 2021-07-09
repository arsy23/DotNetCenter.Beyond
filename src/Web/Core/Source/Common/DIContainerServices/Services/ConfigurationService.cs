
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    public class ConfigurationService 
        : SupportConfiguration
    {
        #region Constructor
        public ConfigurationService(IConfiguration configuration) 
            => _configuration = configuration;
        #endregion

        public IConfiguration Configuration => _configuration;
        private readonly IConfiguration _configuration;

    }
}
