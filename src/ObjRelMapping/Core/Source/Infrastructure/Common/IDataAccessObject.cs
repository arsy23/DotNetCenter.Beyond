using DotNetCenter.Core;
using DotNetCenter.Core.Entities;
using System;
using Sys = System;

namespace DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common
{
    public interface IDataAccessObject<TKey> : Entity<TKey>
           where TKey : IEquatable<TKey>
    {
    }
}