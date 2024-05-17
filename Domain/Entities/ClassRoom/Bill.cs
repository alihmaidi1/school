using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Bill:BaseEntity
    {

        public Bill(){

            Id=Guid.NewGuid();
        }

        public DateTime Date{get;set;}
        public float Money{get;set;}


        public Guid YearId{get;set;}

        public Year Year{get;set;}

        public Guid ClassId{get;set;}


        public Class Class{get;set;}
    }
