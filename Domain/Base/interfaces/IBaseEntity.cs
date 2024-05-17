using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Base.interfaces;

public interface IBaseEntity
{



    public DateTime DateCreated { get; set; }

    public DateTime? DateDeleted { get; set; }


    public DateTime? DateUpdated { get; set; }


    public Guid? CreatedBy { get; set; }
    public Guid? UpdatedBy { get; set; }
    public Guid? DeletedBy { get; set; }


}
