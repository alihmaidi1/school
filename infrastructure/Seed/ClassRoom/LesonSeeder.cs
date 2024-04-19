using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

public static class LesonSeeder
{


    public static Task SeedData(ApplicationDbContext context){


        if(!context.Lesons.Any()){


            var SubjectYear=context.SubjectYears.Select(x=>x.Id).ToList();

            var Lesons=LesonFaker.GetFaker(SubjectYear).Generate(100);
            context.Lesons.AddRange(Lesons);
            context.SaveChanges();
        }

        return Task.CompletedTask;

    }   

}
