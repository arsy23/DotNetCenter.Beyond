namespace DotNetCenter.Beyond.Web.Identity.Core.Common.DbContextServices
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using DotNetCenter.DateTime.Common;
    using Microsoft.EntityFrameworkCore;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Core.Entities;
    using System;
    
    public class Auditor<TKeyEntity, TKeyUser> : Auditable
        where TKeyUser : struct, IEquatable<TKeyUser>
        where TKeyEntity : struct, IEquatable<TKeyEntity>
    {
        private readonly CurrentUserService<TKeyUser> _currentUserService;
        private readonly CompoundableDateTimeNow _dateTime;
        public Auditor(CurrentUserService<TKeyUser> currentUserService, CompoundableDateTimeNow dateTime)
        {
            _currentUserService = currentUserService;
            _dateTime = dateTime;
        }
        /// <summary>
        /// Update Modified Informations to all the Entities in change tracker thats in modified state
        /// </summary>
        /// <param name="changeTracker"></param>
        public void UpdateModifiedAll(ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries<AuditableEntity<TKeyEntity, TKeyUser>>())
                switch (entry.State)
                {
                    //case EntityState.Added:
                    //        entry.Entity.EntityCreated(_currentUserService.UserId, _dateTime.DateTimeNow);
                            //break;
                    case EntityState.Modified:
                            entry.Entity.RegisterModifiedInformation(_currentUserService.UserId, _dateTime.DateTimeNow);
                            break;
                }
            }
    }
}
