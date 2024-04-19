using Bogus;
using Domain.Entities.Class.Year;

namespace infrutructure.Data.Class;

public static class YearFaker
{

    public static Faker<Year> GetBillFaker()
    {

        var YearFaker = new Faker<Year>();
        YearFaker.RuleFor(x => x.Name, setter => setter.Date.Between(DateTime.Now.AddYears(-20), DateTime.Now).Year);
        return YearFaker;
    }
}