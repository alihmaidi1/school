using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;

namespace Domain.Entities.Quez;

public class Quez:BaseEntity,ISoftDelete
{

    public Quez(){

        Id=Guid.NewGuid();
        StudentQuezs=new HashSet<StudentQuez>();

        Questions=new HashSet<Question>();
    }


    public string Name{get;set;}

    public DateTime StartAt{get;set;}

    public ICollection<Question> Questions{get;set;}

    

    public ICollection<StudentQuez> StudentQuezs{get;set;}


    public bool IsPending(){

        return StartAt>DateTime.Now;
    }

    public bool IsFinished(){


        var TotalTime=StartAt.AddSeconds(Questions.Sum(x=>x.Time));
        return TotalTime<DateTime.Now;


    }


    public bool IsBelongForId(Guid id){

        return StudentQuezs.First().StudentSubject.SubjectYear.TeacherId==id; 
    }
}
