namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    public class AppRole
        : IdentityRole<int>
        , IAppRole
    { 
        public AppRole() { }
        public AppRole(string name) 
            => Name = name;
        public AppRole(string name, string _description)
        {
            Name = name;
            Description = _description;
        }
        public string Description { get; set; }
        public string Tag { get; set;}
        #region Audit
        public virtual int? ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDateTime { get; set; }
        public virtual int CreatedBy { get; set; }
        public virtual DateTime CreatedDateTime { get; set; }
        #endregion
    }
}
