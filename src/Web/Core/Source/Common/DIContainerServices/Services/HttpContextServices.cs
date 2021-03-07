namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class HttpContextServices : SupportHttpContextServices
    {
        #region Constructor
        public HttpContextServices(IHttpContextAccessor httpContextAccessor) 
            => _httpContextAccessor = httpContextAccessor;
        #endregion

        /// <summary>
        /// Using IHttpAccessor Cusing PerfObjRelMappingance Issue like hard debugging.. Don't using 
        /// this when as possible
        /// </summary>
        public IHttpContextAccessor HttpContextAccessor => _httpContextAccessor;
        private readonly IHttpContextAccessor _httpContextAccessor;

    }
}
