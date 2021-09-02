using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
using DotNetCenter.Core.Entities;
using System;

namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    public interface IAppRole: PersistableObject<int, int, int>
    {
        public string Name { get; }
        public string Description { get; }
        public string Tag { get; }
    }
}