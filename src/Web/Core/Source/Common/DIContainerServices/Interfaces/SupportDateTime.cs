using DotNetCenter.DateTime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DotNetCenter.Beyond.Web.Core.Common.DIContainerServices.Interfaces
{
    public interface SupportDateTime<TAppDateTimeNowService, TAppDateTimeService>
        where TAppDateTimeNowService : CompoundableDateTimeNow
        where TAppDateTimeService : CompoundableDateTime
    {
        public TAppDateTimeNowService DateTimeNowService { get; }
        public TAppDateTimeService DateTimeService { get; }
    }
}
