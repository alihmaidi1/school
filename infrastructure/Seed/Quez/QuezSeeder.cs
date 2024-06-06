using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Domain.Entities.Quez;
using infrastructure.Data.Quez;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Seed.Quez;

public static class QuezSeeder
{

    public static async Task seedData(ApplicationDbContext context){


        if(!context.Quezs.Any()){

            var Quezes=new List<Domain.Entities.Quez.Quez>();


            List<SubjectYear> subjectYears=context
            .SubjectYears
            .Include(x=>x.StudentSubjects)
            .ThenInclude(x=>x.Student)
            .ToList();
            subjectYears.ForEach(x=>{

                Quezes.AddRange(QuezFaker.GetFaker(x).Generate(5));

            });

            context.Quezs.AddRange(Quezes);
            context.SaveChanges();


        }

    }




}
