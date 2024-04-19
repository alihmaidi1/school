namespace Shared.Entity.Entity;

public interface IRemovable
{
    public DateTime? DateDeleted { get; set; }
    public Guid? DeletedBy { get; set; }

    
}