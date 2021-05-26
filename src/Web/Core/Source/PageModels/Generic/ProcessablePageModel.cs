using DotNetCenter.Beyond.Web.Core.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DotNetCenter.Beyond.Web.Core.PageModels.Generic
{
    public interface ProcessablePageModel<TPageModel> : ProcessablePageModel
        where TPageModel : ProcessableEntry
    {
    }
}
