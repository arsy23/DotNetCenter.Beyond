namespace DotNetCenter.Beyond.Web.Mvc.RazorPages.PageModels
{
    using MediatR;
    using global::AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Mvc.Core;
    using DotNetCenter.DateTime.Common;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Http;
    using DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces;
    using DotNetCenter.Beyond.Web.Core.PageModels;

    public abstract class BasePageModel 
        : PageModel
        , ProcessablePageModel
    {
        public abstract class DataPageModel
        {
            public virtual string Name => nameof(BasePageModel)
                .Replace("PageModel", "");
            public virtual string ActionName => "OnGet";
        }
    }

    public abstract class BasePageModel<TPageModel, TDateTimeNowService, TDateTimeService> : BasePageModel
        where TPageModel : ProcessablePageModel
        where TDateTimeService : CompoundableDateTime
        where TDateTimeNowService : CompoundableDateTimeNow
    {
        protected TDateTimeService DateTimeService => _dateTimeService ??= HttpContext.RequestServices.GetService<TDateTimeService>();
        private TDateTimeService _dateTimeService;
        protected TDateTimeNowService DateTimeNowService => _dateTimeNowService ??= HttpContext.RequestServices.GetService<TDateTimeNowService>();
        private TDateTimeNowService _dateTimeNowService;

    }
}
