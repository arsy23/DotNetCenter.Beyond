namespace DotNetCenter.Beyond.Web.Identity.Core.Common.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    public class AppRole<TKeyRole> 
        : IdentityRole<TKeyRole> where TKeyRole : IEquatable<TKeyRole>
    {
        public AppRole()
        { }
        public AppRole(string name)
        {
            Name = name;
        }
        public AppRole(string name, string _description)
        {
            Name = name;
            Description = _description;
        }
        public string Description { get; private set; }
    }
}
