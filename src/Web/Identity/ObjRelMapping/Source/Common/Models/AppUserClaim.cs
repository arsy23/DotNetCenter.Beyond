namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class AppUserClaim
        : IdentityUserClaim<int>
        , IAppUserClaim
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDateTime { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
    }
}
