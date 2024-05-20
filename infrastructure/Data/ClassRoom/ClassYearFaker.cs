using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.ClassRoom;

namespace infrastructure.Data.ClassRoom;

public class ClassYearFaker
{

    public static Faker<ClassYear> GetFaker(List<Guid> years,List<Class> classes){


        var ClassYear=new Faker<ClassYear>();
        ClassYear.RuleFor(x=>x.ClassId,setter=>setter.PickRandom(classes).Id);
        ClassYear.RuleFor(x=>x.YearId,setter=>setter.PickRandom(years));
        ClassYear.RuleFor(x=>x.Status,setter=>false);
        ClassYear.RuleFor(x=>x.Bills,setter=>BillFaker.GetFaker().Generate(5));
        ClassYear.RuleFor(x=>x.SubjectYears,classes.SelectMany(x=>x.Subjects).Select(x=>new SubjectYear{

            TeacherId=x.Teachers.First().Id

        }).ToList());
        return ClassYear;

    }

}
