using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Student.StudentSubject;

namespace infrastructure.Data.Student;

public static class StudentSubjectFaker
{


    public static Faker<StudentSubject> GetFaker(List<Guid> Students,List<Guid> SubjectYears)
    {


        var StudentSubject=new Faker<StudentSubject>();
        StudentSubject.RuleFor(x=>x.Mark,setter=>setter.Random.Float(0,100));
        StudentSubject.RuleFor(x=>x.StudentId,setter=>setter.PickRandom(Students));
        StudentSubject.RuleFor(x=>x.SubjectYearId,setter=>setter.PickRandom(SubjectYears));
        return StudentSubject;

    }

}
