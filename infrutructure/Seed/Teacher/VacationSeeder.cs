using Domain.Entities.Admin;
using Domain.Entities.Teacher.Vacation;
using infrutructure.Data.Teacher;

namespace infrutructure.Seed.Teacher;

public static class VacationSeeder
{
    
    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.Vacations.Any())
        {

            List<Domain.Entities.Teacher.Teacher.Teacher> teachers = context.Teachers.ToList();
            List<Admin> managers = context.Admins.ToList();
            List<Vacation> vacations = VacationFaker.GetVacationFaker(teachers,managers).Generate(10);
            context.AddRange(vacations);
            context.SaveChanges();
        }


    }

}