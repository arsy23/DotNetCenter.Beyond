using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DotNetCenter.Beyond.Web.Core.Controllers.Generic
{
    public interface ProcessableController<TController> : ProcessableController
        where TController : ProcessableController
    {

    }
}
