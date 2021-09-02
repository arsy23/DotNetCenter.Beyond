using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
using DotNetCenter.Beyond.Web.Identity.Services.DbContextServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.Web.Identity.Services.DependencyResolution
{
    public static class AuditorDIC
    {
        public static IServiceCollection AddAuditor(this IServiceCollection services)
        {
            services.AddSingleton<Auditable, Auditor>();
            return services;
        }
    }
}
