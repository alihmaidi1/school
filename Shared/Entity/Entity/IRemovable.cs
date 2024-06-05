namespace Shared.Entity.Entity;

public interface IRemovable
{
    public DateTimeOffset? DateDeleted { get; set; }
    public Guid? DeletedBy { get; set; }

    
}