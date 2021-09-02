namespace DotNetCenter.Beyond.Web.Identity.Services.DbContextServices
{
    using DotNetCenter.Beyond.ObjRelMapping.Core.Auditing;
    using DotNetCenter.Beyond.ObjRelMapping.Core.Infrastructure.Common;
    using DotNetCenter.Beyond.Web.Identity.Core;
    using DotNetCenter.Beyond.Web.Identity.Services.Managers;
    using DotNetCenter.Core.Entities;
    using DotNetCenter.DateTime.Common;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;

    public class Auditor: Auditable
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
        public virtual void UpdateModifiedAll(ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries<ModifiableEntity<int>>())
                switch (entry.State)
                {
                    //case EntityState.Added:
                    //        entry.Entity.EntityCreated(_currentUserService.UserId, _dateTime.DateTimeNow);
                    //break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = _currentUserService.UserId;
                        entry.Entity.ModifiedDateTime = _dateTime.DateTimeNow;
                        break;
                }
        }
        /// <summary>
        /// Update Modified Informations to all the Entities in change tracker thats in modified state
        /// </summary>
        /// <param name="changeTracker"></param>
        public virtual void UpdateCreatorAll(ChangeTracker changeTracker)
        {
            foreach (var entry in changeTracker.Entries<CreatableEntity<int>>())
                switch (entry.State)
                {
                    //case EntityState.Added:
                    //        entry.Entity.EntityCreated(_currentUserService.UserId, _dateTime.DateTimeNow);
                    //break;
                    case EntityState.Modified:
                        entry.Entity.CreatedBy = _currentUserService.UserId ?? throw new NullReferenceException();
                        entry.Entity.CreatedDateTime = _dateTime.DateTimeNow;
                        break;
                }
        }
    }
}
