
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using DotNetCenter.Beyond.Web.Core.Controllers;
using Microsoft.AspNetCore.Http;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    public sealed class AllDotNetCenterServices
        : SupportAllDotNetCenterServices
    {
        #region Constructor
        public AllDotNetCenterServices(
            SupportConfiguration configurationService
            , SupportAutoMapper automapperService
            , SupportMediateR mediateRService)
        {
            _configurationService = configurationService;
            _automapperService = automapperService;
            _mediateRService = mediateRService;
        }
        #endregion

        public SupportConfiguration ConfigurationService => _configurationService;
        private readonly SupportConfiguration _configurationService;

        public SupportAutoMapper AutoMapperService => _automapperService;
        private readonly SupportAutoMapper _automapperService;

        public SupportMediateR MediateRService =>_mediateRService;
        private readonly SupportMediateR _mediateRService;

    }
}
