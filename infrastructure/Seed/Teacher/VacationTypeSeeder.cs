using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Warning;
using infrastructure.Data.Teacher;

namespace infrastructure.Seed.Teacher;

public static class VacationTypeSeeder
{


    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.VacationTypes.Any())
        {

            List<VacationType> vacations = VacationTypeFaker.GetVacationFaker().Generate(10);
            context.VacationTypes.AddRange(vacations);
            await context.SaveChangesAsync();
        }

    }   

}
