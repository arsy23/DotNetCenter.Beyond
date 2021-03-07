namespace DotNetCenter.Beyond.Web.Api.Controllers
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Mvc;
    using DotNetCenter.Beyond.Web.Core.Controllers;
    using DotNetCenter.DateTime.Common;
    using Microsoft.AspNetCore.Http;

    public abstract class BaseApiController : ControllerBase, ProcessableController
    {
        public abstract class DataController
        {
            public virtual string Name => nameof(BaseApiController)
                .Replace("Controller", "");
            public virtual string ActionName => "Index";
        }
    }
    public abstract class BaseApiController<TApiController, TDateTimeNowService, TDateTimeService> : BaseApiController
    where TApiController : ProcessableController
    where TDateTimeService : CompoundableDateTime
    where TDateTimeNowService : CompoundableDateTimeNow
    {
        protected TDateTimeService DateTimeService => _dateTimeService ??= HttpContext.RequestServices.GetService<TDateTimeService>();
        private TDateTimeService _dateTimeService;
        protected TDateTimeNowService DateTimeNowService => _dateTimeNowService ??= HttpContext.RequestServices.GetService<TDateTimeNowService>();
        private TDateTimeNowService _dateTimeNowService;
    }
}
