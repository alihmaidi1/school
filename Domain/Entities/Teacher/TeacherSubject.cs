using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.ClassRoom;
using Domain.Entities.Teacher.Teacher;

namespace Domain.Entities.Teacher;

public class TeacherSubject:BaseEntity,ISoftDelete
{

    public TeacherSubject(){

        Id=Guid.NewGuid();

        SubjectYears=new HashSet<SubjectYear>();
    }


    public Teacher.Teacher Teacher{get;set;}
    public Guid TeacherId{get;set;}

    public Subject Subject{get;set;}

    public Guid SubjectId{get;set;}

    public ICollection<SubjectYear> SubjectYears{get;set;}

}
