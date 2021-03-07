using Microsoft.AspNetCore.Http;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces
{
    public interface SupportHttpContextServices
    {
        public IHttpContextAccessor HttpContextAccessor { get; }
    }
}
