using Bogus;
using Domain.Entities.Class.ClassYear;
using Domain.Entities.Class.Year;

namespace infrutructure.Data.Class;

public static class ClassYearFaker
{
    public static Faker<ClassYear> GetClassYearFaker(List<Domain.Entities.Class.Class.Class> classes,List<Year> years)
    {

        var ClassYear = new Faker<ClassYear>();
        ClassYear.RuleFor(x => x.ClassId, setter => setter.PickRandom(classes).Id);
        ClassYear.RuleFor(x=>x.YearId,setter=>setter.PickRandom(years).Id);
        return ClassYear;


    }

}