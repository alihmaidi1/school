using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Domain.Entities.ClassRoom;
using LinqKit;
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


    public DateTimeOffset EndAt{get;set;}

    public ICollection<Question> Questions{get;set;}

    
    public SubjectYear SubjectYear{get;set;}

    public Guid SubjectYearId{get;set;}

    public ICollection<StudentQuez> StudentQuezs{get;set;}

    



    public static Expression<Func<Quez,bool>> IsFinished(){
                    
        return quez=>quez.EndAt<DateTimeOffset.UtcNow;
    }


    public static Expression<Func<Quez,bool>> IsNotStarted(){


        return x=>x.StartAt>DateTimeOffset.UtcNow;

    }

    public static Expression<Func<Quez,bool>> IsBelongForId(Guid id){
        
        return quez=>quez.SubjectYear.TeacherId==id; 
    }
}
