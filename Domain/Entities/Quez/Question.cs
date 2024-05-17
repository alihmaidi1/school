using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.Quez;

public class Question: BaseEntity,ISoftDelete
{


    public Question(){

        Id=Guid.NewGuid();

        Answers=new HashSet<Answer>();
    }


    public string Name{get;set;}


    public Guid QuezId{get;set;}

    public Quez.StudentQuez Quez{get;set;}

    public ICollection<Answer> Answers{get;set;}


}
