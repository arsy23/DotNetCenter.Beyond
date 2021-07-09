namespace DotNetCenter.Beyond.Web.Mvc.Controllers
{
    using global::AutoMapper;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;
    using DotNetCenter.Beyond.Web.Core.Controllers;
    using Microsoft.AspNetCore.Http;
    
    using DotNetCenter.Beyond.Web.Core.Controllers.Generic;
    using DotNetCenter.DateTime.Common;

    public abstract class BaseController : Controller, ProcessableController
    {
        public abstract class DataController
        {
            public virtual string Name => nameof(BaseController)
                .Replace("PageModel", "");
            public virtual string ActionName => "Index";
        }
    }
    public abstract class BaseController<TController, TDateTimeNowService, TDateTimeService> 
        : BaseController
        where TController : ProcessableController
         where TDateTimeService : CompoundableDateTime
         where TDateTimeNowService : CompoundableDateTimeNow
    {
        protected TDateTimeService DateTimeService => _dateTimeService ??= HttpContext.RequestServices.GetService<TDateTimeService>();
        private TDateTimeService _dateTimeService;
        protected TDateTimeNowService DateTimeNowService => _dateTimeNowService ??= HttpContext.RequestServices.GetService<TDateTimeNowService>();
        private TDateTimeNowService _dateTimeNowService;

    }
}
