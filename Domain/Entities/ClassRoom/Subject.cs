using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Teacher;
using Domain.Entities.Teacher.Teacher;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class Subject:BaseEntity,ISoftDelete
    {


        public Subject(){

            Id=Guid.NewGuid();
        }


        public float MinDegree{get;set;}


        public float Degree{get;set;}
        public string Name{get;set;}

        public Guid ClassId{get;set;}

        public Class Class{get;set;}

        // public ICollection<Teacher.Teacher.Teacher> Teachers{get;set;}

        public ICollection<TeacherSubject> TeacherSubjects{get;set;}



    }
