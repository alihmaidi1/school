using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure.Data.Quez;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Seed.Quez;

public static class QuezSeeder
{

    public static async Task seedData(ApplicationDbContext context){


        if(!context.Quezs.Any()){



            List<SubjectYear> subjectYears=context
            .SubjectYears
            .Include(x=>x.StudentSubjects)
            .ThenInclude(x=>x.Student)
            .ToList();
            var Quezes=QuezFaker.GetFaker(subjectYears).Generate(40);
            context.Quezs.AddRange(Quezes);
            context.SaveChanges();


        }

    }




}
