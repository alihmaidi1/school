using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Teacher;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Subject:BaseEntity
    {


        public Subject(){

            Id=Guid.NewGuid();
            SubjectYears=new HashSet<SubjectYear>();
            Teachers=new HashSet<Teacher.Teacher.Teacher>();
        }

        public string Name{get;set;}

        public Guid ClassId{get;set;}

        public Class Class{get;set;}

        public ICollection<SubjectYear> SubjectYears{get;set;}

        public ICollection<Teacher.Teacher.Teacher> Teachers{get;set;}

    }
