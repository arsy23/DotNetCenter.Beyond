using Microsoft.AspNetCore.Http;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    public interface SupportHttpContextServices
    {
        public IHttpContextAccessor HttpContextAccessor { get; }
    }
}
