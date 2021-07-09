namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    using DotNetCenter.Beyond.Web.Core.Common;
    using Microsoft.Extensions.Logging;
    public interface SupportLoggingServices<TController>
where TController : ProcessableEntry
    {
        public ILogger<TController> Logger { get; }
    }
}
