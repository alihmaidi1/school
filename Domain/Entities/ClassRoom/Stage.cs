using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Stage: BaseEntity,ISoftDelete
    {

        public Stage(){

            Id=Guid.NewGuid();
            Classes=new HashSet<Class>();
        }

        public string Name{get;set;}
        public ICollection<Class> Classes{get;set;}


    }
