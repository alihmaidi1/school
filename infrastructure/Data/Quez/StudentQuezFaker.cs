using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Quez;

namespace infrastructure.Data.Quez;

public class StudentQuezFaker
{


    public static Faker<StudentQuez> GetFaker(List<Guid> Students)
    {

        var StudentQuez=new Faker<StudentQuez>();
        StudentQuez.RuleFor(x=>x.StudentId,setter=>setter.PickRandom(Students));
        return StudentQuez;

   }

}
