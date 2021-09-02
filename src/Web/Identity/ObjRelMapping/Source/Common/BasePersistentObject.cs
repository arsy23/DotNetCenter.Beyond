using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Configuration;
using DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Sys = System;
namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common
{
    public abstract class BasePersistentObject<TKey, TAppUser> : BaseDataAccessObject<TKey>, PersistableObject<TKey, TAppUser, int>
         where TAppUser : IIdentityUser
         where TKey : struct, IEquatable<TKey>
    {
        public override TKey Id { get => base.Id; set => base.Id = value; }
        public virtual int? ModifiedBy { get; set; }
        public virtual Sys.DateTime? ModifiedDateTime { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual Sys.DateTime CreatedDateTime { get; set; }

    }
}
