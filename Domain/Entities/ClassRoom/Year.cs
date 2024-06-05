using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Year: BaseEntity,ISoftDelete
    {

        public Year(){


            Id=Guid.NewGuid();

            ClassYears=new HashSet<ClassYear>();
        }

        public DateTimeOffset Date{get;set;}

        public ICollection<ClassYear> ClassYears{get;set;}


    }
