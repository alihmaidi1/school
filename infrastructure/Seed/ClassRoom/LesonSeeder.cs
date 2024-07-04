using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

public static class LesonSeeder
{


    public static Task SeedData(ApplicationDbContext context){


        if(!context.Lesons.Any()){


            var SubjectYear=context.SubjectYears.Select(x=>x.Id).ToList();
            var Lesons=new List<Leson>();
            SubjectYear.ForEach(x=>{

                Lesons.AddRange(LesonFaker.GetFaker(x).Generate(2));
                
            });

            context.Lesons.AddRange(Lesons);
            context.SaveChanges();
        }

        return Task.CompletedTask;

    }   

}
