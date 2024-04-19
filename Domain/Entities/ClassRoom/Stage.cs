using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Stage: BaseEntity
    {

        public Stage(){

            Id=Guid.NewGuid();
            Classes=new HashSet<Class>();
        }

        public string Name{get;set;}
        public ICollection<Class> Classes{get;set;}


    }
