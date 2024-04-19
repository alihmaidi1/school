using Bogus;
using Domain.Entities.Admin;
using Domain.Entities.Teacher.Vacation;

namespace infrutructure.Data.Teacher;

public static class VacationFaker
{
    public static Faker<Vacation> GetVacationFaker(List<Domain.Entities.Teacher.Teacher.Teacher> teachers,List<Admin> managers)
    {


        var Vacation= new Faker<Vacation>();

        Vacation.RuleFor(x => x.Reason, setter => setter.Random.Words(100));
        Vacation.RuleFor(x => x.Date, setter =>setter.Date.Between(DateTime.Now.AddYears(-14),DateTime.Now).ToString("YYYY"));
        Vacation.RuleFor(x => x.TeacherId, setter => setter.PickRandom(teachers).Id);
        Vacation.RuleFor(x => x.AdminId, setter => setter.PickRandom(managers).Id);
        Vacation.RuleFor(x => x.Status, setter => setter.Random.Bool());
        
        return Vacation;

        
        
        
    }
    
}