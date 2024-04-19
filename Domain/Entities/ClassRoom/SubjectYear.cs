using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Student.StudentSubject;
using Shared.Entity.Entity;

namespace Domain.Entities.ClassRoom;

    public class SubjectYear:BaseEntity
    {

        public SubjectYear(){

            Id=Guid.NewGuid();
            StudentSubjects=new HashSet<StudentSubject>();
        
            Lesons=new HashSet<Leson>();
        }

        public Guid SubjectId{get;set;}

        public Subject Subject {get;set;}


        public Guid YearId{get;set;}

        public Year Year{get;set;}

        public Teacher.Teacher.Teacher Teacher{get;set;}

        public Guid TeacherId{get;set;}


        public ICollection<StudentSubject> StudentSubjects{get;set;}

        public ICollection<Leson> Lesons{get;set;}

    }
