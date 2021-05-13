namespace DotNetCenter.Beyond.Web.Identity.ObjRelMapping.DbContextServices
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Core.Entities;
    using DotNetCenter.DateTime.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;

    public class Auditor : Auditable
    {
        private readonly CurrentUserService _currentUserService;
        private readonly CompoundableDateTimeNow _dateTime;
        public Auditor(CurrentUserService currentUserService, CompoundableDateTimeNow dateTime)
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
            foreach (var entry in changeTracker.Entries<AuditableEntity<Guid, Guid>>())
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
