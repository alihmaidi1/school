using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Quez;

namespace infrastructure.Data.Quez;

public class StudentQuezFaker
{


    public static Faker<StudentQuez> GetFaker(List<Guid> StudentSubjects)
    {

        var StudentQuez=new Faker<StudentQuez>();

        StudentQuez.RuleFor(x=>x.Name,setter=>setter.Random.Words(1));
        StudentQuez.RuleFor(x=>x.StartAt,setter=>DateTime.Now.AddMonths(setter.Random.Int(1,4)));
        StudentQuez.RuleFor(x=>x.EndAt,setter=>DateTime.Now.AddMonths(setter.Random.Int(4,8)));
        StudentQuez.RuleFor(x=>x.StudentSubjectId,setter=>setter.PickRandom(StudentSubjects));
        StudentQuez.RuleFor(x=>x.Questions,setter=>QuestionFaker.GetFaker().Generate(setter.Random.Int(10,20)));
        return StudentQuez;

   }

}
