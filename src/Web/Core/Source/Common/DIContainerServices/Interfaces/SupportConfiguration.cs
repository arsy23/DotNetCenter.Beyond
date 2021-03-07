using Microsoft.Extensions.Configuration;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces
{
    public interface SupportConfiguration
    {
        public IConfiguration Configuration { get; }
    }
}
