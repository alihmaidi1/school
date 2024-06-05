using Bogus;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Vacation;

namespace infrastructure.Data.Teacher;

public static class VacationFaker
{
    public static Faker<Vacation> GetVacationFaker(List<Domain.Entities.Teacher.Teacher.Teacher> teachers,List<Admin> managers,List<Guid> VacationTypes)
    {


        var Vacation= new Faker<Vacation>();

        Vacation.RuleFor(x => x.Reason, setter => setter.Random.Words(100));
        Vacation.RuleFor(x => x.Date, setter =>setter.Date.Between(DateTime.Now.AddYears(-14),DateTime.Now));
        Vacation.RuleFor(x => x.TeacherId, setter => setter.PickRandom(teachers).Id);
        Vacation.RuleFor(x => x.AdminId, setter => setter.PickRandom(managers).Id);
        Vacation.RuleFor(x => x.Status, setter => setter.Random.Bool());
        Vacation.RuleFor(x=>x.TypeId,setter=>setter.PickRandom(VacationTypes));
        return Vacation;

        
        
        
    }
    
}