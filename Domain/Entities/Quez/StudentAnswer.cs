using Domain.Base.Entity;

namespace Domain.Entities.Quez;

public class StudentAnswer: BaseEntity
{

    public StudentAnswer(){


        Id=Guid.NewGuid();
    }


    public Guid AnswerId{get;set;}

    public Answer Answer {get;set;}

    public Guid StudentQuizId{get;set;}

    public StudentQuez StudentQuez{get;set;}



}
