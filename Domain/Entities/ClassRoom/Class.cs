using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Class: BaseEntity,ISoftDelete
    {

        public Class(){

            Id=Guid.NewGuid();
            Subjects=new HashSet<Subject>();
            Bills=new HashSet<Bill>();
        }

        public string Name{get;set;}


        public Guid StageId{get;set;}

        public Stage Stage{get;set;}


        public ICollection<Subject> Subjects{get;set;} 


        public ICollection<Bill> Bills{get;set;}

    }
