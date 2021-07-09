namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    using Microsoft.Extensions.Logging;
    public interface SupportPreConfiguration
    {
        public SupportLoggerProviders LoggerProviders { get; }
        public SupportWebHosting WebHosting { get; }
        public SupportConfiguration Configuration { get; }
    }
}
