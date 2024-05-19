using Domain.Base.Entity;
using Domain.Base.interfaces;
using Shared.Entity.Entity;

namespace Domain.Entities.Quez;

public class Question: BaseEntity,ISoftDelete
{


    public Question(){

        Id=Guid.NewGuid();

        Answers=new HashSet<Answer>();
    }


    public string? Name{get;set;}


    public int Time{get;set;}

    public float Score{get;set;}

    public string? Image{get;set;}

    public Guid QuezId{get;set;}

    public Domain.Entities.Quez.Quez Quez{get;set;}

    public ICollection<Answer> Answers{get;set;}


}
