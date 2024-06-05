using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.ClassRoom;
using Domain.Entities.Quez;
using Domain.Entities.Student.Student;
using Shared.Entity.Entity;

namespace Domain.Entities.Student.StudentSubject;

public class StudentSubject: BaseEntity,ISoftDelete 
{

    public StudentSubject(){

        Id=Guid.NewGuid();

    }

    public Guid StudentId{get;set;}


    public Student.Student Student{get;set;}


    public Guid SubjectYearId{get;set;}
    public SubjectYear SubjectYear{get;set;}


    public float? Mark{get;set;}


}
