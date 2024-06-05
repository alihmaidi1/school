using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.ClassRoom;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Domain.Entities.Quez;

public class Quez:BaseEntity,ISoftDelete
{

    public Quez(){

        Id=Guid.NewGuid();
        StudentQuezs=new HashSet<StudentQuez>();

        Questions=new HashSet<Question>();
    }


    public string Name{get;set;}

    public DateTimeOffset StartAt{get;set;}

    public ICollection<Question> Questions{get;set;}

    
    public SubjectYear SubjectYear{get;set;}

    public Guid SubjectYearId{get;set;}

    public ICollection<StudentQuez> StudentQuezs{get;set;}

    



    public static bool IsFinished(Quez quez){


        var TotalTime=quez.StartAt.AddSeconds(quez.Questions.Sum(x=>x.Time));
        return TotalTime<DateTime.Now;


    }




    public static bool IsBelongForId(Quez quez,Guid id){

        return true;
        // return quez.StudentQuezs.First().StudentSubject.SubjectYear.TeacherId==id; 
    }
}
