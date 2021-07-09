using Microsoft.Extensions.Configuration;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    public interface SupportConfiguration
    {
        public IConfiguration Configuration { get; }
    }
}
