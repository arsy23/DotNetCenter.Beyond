using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Configuration
{
    public abstract class BaseDataAccessObject<TKey> : InfrastructureDao<TKey>
        where TKey : IEquatable<TKey>

    {
        public virtual TKey Id { get; set; }
    }
}
