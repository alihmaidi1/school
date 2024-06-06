using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Teacher;

namespace infrastructure.Data.ClassRoom;

public class TeacherSubjectFaker
{

    public static Faker<TeacherSubject> GetFaker(List<Guid> Subjects){

        var TeacherSubject=new Faker<TeacherSubject>();
        TeacherSubject.RuleFor(x=>x.SubjectId,setter=>setter.PickRandom(Subjects));
        return TeacherSubject;

    }
}
