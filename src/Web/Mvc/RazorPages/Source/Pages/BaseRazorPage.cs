namespace DotNetCenter.Beyond.Web.Mvc.RazorPages.Pages
{
    using MediatR;
    using global::AutoMapper;
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Mvc.Core;
    using DotNetCenter.DateTime.Common;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.AspNetCore.Http;
    
    using DotNetCenter.Beyond.Web.Core.PageModels;
    using Microsoft.AspNetCore.Mvc.Razor.Extensions;

    public abstract class BaseRazorPage
        : RazorPage
        , ProcessablePageModel
    {
        public abstract class DataRazorPage
        {
            public virtual string Name => nameof(BaseRazorPage)
                .Replace("Page", "");
            public virtual string ActionName => "OnGet";
        }
    }

    public abstract class BaseRazorPage<TPageModel, TDateTimeNowService, TDateTimeService> : RazorPage<TPageModel>
        where TPageModel : ProcessablePageModel
        where TDateTimeService : CompoundableDateTime
        where TDateTimeNowService : CompoundableDateTimeNow
    {
        protected TDateTimeService DateTimeService => _dateTimeService ??= Context.RequestServices.GetService<TDateTimeService>();
        private TDateTimeService _dateTimeService;
        protected TDateTimeNowService DateTimeNowService => _dateTimeNowService ??= Context.RequestServices.GetService<TDateTimeNowService>();
        private TDateTimeNowService _dateTimeNowService;

    }
}
