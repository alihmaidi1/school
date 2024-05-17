using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Base.interfaces;

public interface ISoftDelete
{

    public DateTime? DateDeleted { get; set; }
    public Guid? DeletedBy { get; set; }


}
