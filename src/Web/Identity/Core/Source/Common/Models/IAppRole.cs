using DotNetCenter.Core.Entities;
using System;

namespace DotNetCenter.Beyond.Web.Identity.Core.Models
{
    public interface IAppRole: AuditableEntity<Guid, Guid>
    {
        public string Name { get; }
        public string Description { get; }
        public string Tag { get; }
    }
}