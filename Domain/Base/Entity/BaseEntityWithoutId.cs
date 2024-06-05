using Domain.Base.interfaces;

namespace Domain.Base.Entity;

public class BaseEntityWithoutId:IBaseEntity
{

    private readonly List<IBaseEvent> _domainEvents = new();


    public DateTime DateCreated { get; set; } = DateTime.Now;
    public DateTimeOffset? DateDeleted { get; set; }
    public DateTime? DateUpdated { get; set; }
    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }
    public IReadOnlyList<IBaseEvent> GetDomainEvents()
    {
        return _domainEvents.ToList();
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }

    protected void RaiseDomainEvent(IBaseEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

}
