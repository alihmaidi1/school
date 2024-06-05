using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Vacation;
using infrastructure.Data.Teacher;

namespace infrastructure.Seed.Teacher;

public static class VacationSeeder
{
    
    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.Vacations.Any())
        {

            List<Domain.Entities.Teacher.Teacher.Teacher> teachers = context.Teachers.ToList();
            List<Admin> managers = context.Admins.ToList();
            var VacationTypes=context.VacationTypes.Select(x=>x.Id).ToList();
            List<Vacation> vacations = VacationFaker.GetVacationFaker(teachers,managers,VacationTypes).Generate(10);
            context.AddRange(vacations);
            context.SaveChanges();
        }


    }

}