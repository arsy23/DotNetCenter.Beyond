using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces
{
    public interface SupportWebHosting
    {
        IWebHostEnvironment WebHostEnvService { get; }
        public string WebEnvironmentName { get; }
    }
}
