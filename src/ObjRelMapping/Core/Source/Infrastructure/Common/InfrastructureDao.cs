using System;
using System.Collections.Generic;
using System.Text;

namespace DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common
{
    public interface InfrastructureDao<TKey>
        where TKey : IEquatable<TKey>
    {
    }
}
