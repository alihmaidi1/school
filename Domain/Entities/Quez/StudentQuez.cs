using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.interfaces;
using Domain.Entities.Student.StudentSubject;
using Shared.Entity.Entity;

namespace Domain.Entities.Quez;

public class StudentQuez: BaseEntity,ISoftDelete
{

    public StudentQuez(){

        Id=Guid.NewGuid();

        Questions=new HashSet<Question>();

        StudentAnswers=new HashSet<StudentAnswer>();
    }

    public string Name{get;set;}


    public Guid StudentSubjectId{get;set;}

    public DateTime StartAt{get;set;}

    public DateTime EndAt{get;set;}

    public StudentSubject StudentSubject{get;set;}

    public ICollection<Question> Questions{get;set;}

    public ICollection<StudentAnswer> StudentAnswers{get;set;}

}
