using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    /// <summary>
    /// ####
    /// </summary>
    public interface SupportWebHosting : IWebHostEnvironmentServiceWrapper
    {
        public string WebEnvironmentName
            => Service.EnvironmentName;
        public bool IsDevelopment()
            => Service.IsDevelopment();
        public bool IsProduction()
            => Service.IsProduction();
        public bool IsStaging()
            => Service.IsStaging();
        public bool IsEnvironment(string environmentName)
            => Service.IsEnvironment(environmentName);
    }
    public interface IWebHostEnvironmentServiceWrapper
    {
        IWebHostEnvironment Service { get; }
    }
}
