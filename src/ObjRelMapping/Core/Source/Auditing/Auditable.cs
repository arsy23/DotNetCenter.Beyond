
namespace DotNetCenter.Beyond.ObjRelMapping.Core.Auditing
{
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    public interface Auditable
    {
        /// <summary>
        /// Update Modified Informations foreach entities in Change Tracker thats in modified state
        /// </summary>
        /// <param name="changeTracker"></param>
        void UpdateModifiedAll(ChangeTracker changeTracker);
    }
}
