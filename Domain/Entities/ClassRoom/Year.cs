using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Year: BaseEntity,ISoftDelete
    {

        public Year(){


            Id=Guid.NewGuid();
            Bills=new HashSet<Bill>();
            SubjectYears=new HashSet<SubjectYear>();
        }

        public DateTime Date{get;set;}

        public ICollection<Bill> Bills{get;set;}  

        public ICollection<SubjectYear> SubjectYears{get;set;}      

    }
