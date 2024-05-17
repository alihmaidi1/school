using System.ComponentModel.DataAnnotations;
using Common.Entity.Entity;
using Shared.Entity.Interface;

namespace Shared.Entity.Entity;

public class BaseEntity : BaseEntityWithoutId, IBaseEntity
{

    public BaseEntity()
    {
        
        Id=Guid.NewGuid();
        
    }
    
    public Guid Id { get; set; }
}
