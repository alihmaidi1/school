using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.Student.StudentSubject;
using Shared.Entity.Entity;

namespace Domain.Entities.Quez;

public class StudentQuez: BaseEntity,ISoftDelete
{

    public StudentQuez(){

        Id=Guid.NewGuid();


        StudentAnswers=new HashSet<StudentAnswer>();
    }


    public Guid StudentSubjectId{get;set;}

    public Guid QuezId{get;set;}

    public Quez Quez{get;set;}

    public StudentSubject StudentSubject{get;set;}


    public ICollection<StudentAnswer> StudentAnswers{get;set;}

}
