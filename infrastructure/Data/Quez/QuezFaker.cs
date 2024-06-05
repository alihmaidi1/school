using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;
using Domain.Entities.Quez;

namespace infrastructure.Data.Quez;

public class QuezFaker
{


    public static Faker<Domain.Entities.Quez.Quez> GetFaker(List<SubjectYear> subjectYears)
    {


        var Quez=new Faker<Domain.Entities.Quez.Quez>();
        var Faker=new Faker();
        var SubjectYear=Faker.PickRandom(subjectYears);
        Quez.RuleFor(x=>x.Name,setter=>setter.Random.Word());
        Quez.RuleFor(x=>x.SubjectYearId,setter=>SubjectYear.Id);
        Quez.RuleFor(x=>x.StartAt,setter=>DateTimeOffset.Now.AddDays(setter.Random.Int(1,5)));
        Quez.RuleFor(x=>x.StudentQuezs,setter=>SubjectYear.StudentSubjects.Select(x=>new StudentQuez{

            StudentId=x.StudentId
        }).Distinct().ToList());
        Quez.RuleFor(x=>x.Questions,setter=>QuestionFaker.GetFaker().Generate(setter.Random.Int(10,20)));        
        return Quez;


    }
}
