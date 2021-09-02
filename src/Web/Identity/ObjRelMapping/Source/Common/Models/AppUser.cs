namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    public class AppUser : IdentityUser<int>, IIdentityUser
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public string Tag { get; set; }
        public string DisplayName { get; set; }
        public virtual Guid? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDateTime { get; set; }
        public virtual Guid CreatedBy { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
    }
}