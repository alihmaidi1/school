using Bogus;
using Domain.Entities.Admin;
using Domain.Entities.Teacher.Warning;

namespace infrutructure.Data.Teacher;

public static class WarningFaker
{


    public static Faker<Warning> GetBrandFaker(List<Domain.Entities.Teacher.Teacher.Teacher> Teachers, List<Admin> managers)
    {

        var Warning= new Faker<Warning>();
        Warning.RuleFor(x => x.Reason, setter => setter.Random.Words(100));
        Warning.RuleFor(x => x.TeacherId,setter=>setter.PickRandom(Teachers).Id);
        Warning.RuleFor(x => x.AdminId, setter => setter.PickRandom(managers).Id);
        Warning.RuleFor(x => x.Date, setter =>setter.Date.Between(DateTime.Now.AddYears(-14),DateTime.Now).Year);
        return Warning;

        return null;
    }
    

}