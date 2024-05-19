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
        StudentQuez.RuleFor(x=>x.StudentSubjectId,setter=>setter.PickRandom(StudentSubjects));
        return StudentQuez;

   }

}
