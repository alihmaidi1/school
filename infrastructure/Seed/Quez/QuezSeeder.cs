using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.Quez;

namespace infrastructure.Seed.Quez;

public static class QuezSeeder
{

    public static async Task seedData(ApplicationDbContext context){


        if(!context.StudentQuezs.Any()){



            List<Guid> StudentSubjects=context.StudentSubjects.Select(x=>x.Id).ToList();
            var Quezes=StudentQuezFaker.GetFaker(StudentSubjects).Generate(200);
            context.StudentQuezs.AddRange(Quezes);
            context.SaveChanges();


        }

    }




}
