
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetCenter.DateTime.Common;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Services
{
    public class DateTimeServices<TAppDateTimeNowService, TAppDateTimeService> 
        : SupportDateTime<TAppDateTimeNowService, TAppDateTimeService>
            where TAppDateTimeNowService : CompoundableDateTimeNow
            where TAppDateTimeService : CompoundableDateTime
    {
        #region Constructor
        public DateTimeServices(
            TAppDateTimeNowService dateTimeNowService,
            TAppDateTimeService dateTimeService)
        {
            _dateTimeNowService = dateTimeNowService;
            _dateTimeService = dateTimeService;
        }
        #endregion

        public TAppDateTimeNowService DateTimeNowService => _dateTimeNowService;
        private readonly TAppDateTimeNowService _dateTimeNowService;

        public TAppDateTimeService DateTimeService => _dateTimeService;
        private readonly TAppDateTimeService _dateTimeService;
    }
}
