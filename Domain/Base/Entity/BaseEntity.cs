using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Base.Entity;

public class BaseEntity: BaseEntityWithoutId
{



    public BaseEntity()
    {
        
        Id=Guid.NewGuid();
        
    }
    
    public Guid Id { get; set; }

}
