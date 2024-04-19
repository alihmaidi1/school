using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Shared.Entity.Entity;
using Shared.Services.User;
namespace infrastructure.Interceptor;

public class SoftDeleteInterceptor : SaveChangesInterceptor
{
    
    private readonly ICurrentUserService _currentUserService;
    
    public SoftDeleteInterceptor(ICurrentUserService currentUserService)
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

            if (entry is not { State: EntityState.Deleted, Entity: IRemovable delete }) continue;
            entry.State = EntityState.Modified;
            delete.DateDeleted=DateTime.Now;
            delete.DeletedBy = _currentUserService.UserId;
        }
            
        return base.SavedChanges(eventData, result);
    }
}