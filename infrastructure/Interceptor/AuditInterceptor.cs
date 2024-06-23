using Domain.Base.interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Entity.Interface;
using Shared.Services.User;

namespace infrastructure.Interceptor;

public class AuditInterceptor: SaveChangesInterceptor
{

    
    private readonly ICurrentUserService _currentUserService;

    public AuditInterceptor(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }
    public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
    {
        
        if (eventData.Context is null)
        {
            return result;
        }

        foreach (var entry in eventData.Context.ChangeTracker.Entries())
        {
            IBaseEntity? entity = entry.Entity as IBaseEntity;
            if (entity is null) continue;
            switch (entry.State)
            {
                case EntityState.Deleted:
                    entity.DeletedBy = _currentUserService.GetUserid();
                    break;
                case EntityState.Modified:
                    entity.UpdatedBy = _currentUserService.GetUserid();
                    entity.DateUpdated = DateTime.UtcNow;
                    break;
                case EntityState.Added:
                    entity.CreatedBy = _currentUserService.GetUserid();
                    entity.DateCreated = DateTime.UtcNow;
                    break;
            }
        }
        
        return base.SavedChanges(eventData, result);
    }
}