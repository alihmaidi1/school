using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

    public class YearSeeder
    {



            public static Task SeedData(ApplicationDbContext context){

                if(!context.Years.Any()){

                var Years=YearFaker.GetFaker().Generate(5).DistinctBy(x=>x.Date.Year);
                context.Years.AddRange(Years);
                context.SaveChanges();

                }
                return Task.CompletedTask;

            }

    }
