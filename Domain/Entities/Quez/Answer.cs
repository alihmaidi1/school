using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Base.Entity;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.Quez;

public class Answer: BaseEntity,ISoftDelete
{


    public Answer(){


        Id=Guid.NewGuid();
        StudentAnswers=new HashSet<StudentAnswer>();


    }

    public string Name{get;set;}


    public bool IsCorrect{get;set;}=false;

    public Guid QuestionId{get;set;}

    public Question Question{get;set;}


    public ICollection<StudentAnswer> StudentAnswers{get;set;}
    




}
