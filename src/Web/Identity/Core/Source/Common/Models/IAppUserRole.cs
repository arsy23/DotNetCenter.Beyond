using DotNetCenter.Core.Entities;
using System;

namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    public interface IAppUserRole : AuditableEntity<int, Guid>
    {
    }
}