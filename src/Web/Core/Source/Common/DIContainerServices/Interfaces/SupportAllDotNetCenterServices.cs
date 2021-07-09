namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices
{
    public interface SupportAllDotNetCenterServices
    {
        SupportConfiguration ConfigurationService { get; }
        SupportAutoMapper AutoMapperService { get;  }
        SupportMediateR MediateRService { get; }
    }
}