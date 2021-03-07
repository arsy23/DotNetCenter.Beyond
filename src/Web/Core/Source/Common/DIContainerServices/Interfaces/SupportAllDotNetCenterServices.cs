namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces
{
    public interface SupportAllDotNetCenterServices
    {
        SupportConfiguration ConfigurationService { get; }
        SupportAutoMapper AutoMapperService { get;  }
        SupportMediateR MediateRService { get; }
    }
}