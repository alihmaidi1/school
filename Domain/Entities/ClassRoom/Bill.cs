using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Entities.Student.StudentBill;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Bill:BaseEntity
    {

        public Bill(){

            Id=Guid.NewGuid();
            StudentBills=new HashSet<StudentBill>();
        }

        public DateTime Date{get;set;}
        public float Money{get;set;}

        public ClassYear ClassYear{get;set;}

        public Guid ClassYearId{get;set;}

        public ICollection<StudentBill> StudentBills{get;set;}
    }
