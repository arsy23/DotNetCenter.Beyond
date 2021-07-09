namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    using Microsoft.Extensions.Logging;
    public interface SupportLoggerProviders
    {
        public ILoggerFactory Factory { get; }
    }
}
