using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Quez;

namespace infrastructure.Data.Quez;

public class QuezFaker
{


    public static Faker<Domain.Entities.Quez.Quez> GetFaker(List<Guid> StudentSubjects)
    {


        var Quez=new Faker<Domain.Entities.Quez.Quez>();
        Quez.RuleFor(x=>x.Name,setter=>setter.Random.Word());
        Quez.RuleFor(x=>x.StartAt,setter=>DateTime.Now.AddDays(setter.Random.Int(1,5)));
        Quez.RuleFor(x=>x.StudentQuezs,setter=>StudentQuezFaker.GetFaker(StudentSubjects).Generate(10));
        Quez.RuleFor(x=>x.Questions,setter=>QuestionFaker.GetFaker().Generate(setter.Random.Int(10,20)));        
        return Quez;


    }
}
