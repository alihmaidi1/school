using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.ClassRoom;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Seed.ClassRoom;

public static class ClassYearSeeder
{
    
    public static Task SeedData(ApplicationDbContext context){

        if(!context.ClassYears.Any()){

            var Years=context.Years.Select(x=>x.Id).ToList();
            var Classes=context.Classes.ToList();            
            var ClassYears=ClassYearFaker.GetFaker(Years,Classes).Generate(20);            
            var ActiveClassyear=ClassYears.First();
            ActiveClassyear.Status=true;
            context.ClassYears.AddRange(ClassYears.Skip(1).ToList());
            context.ClassYears.Add(ActiveClassyear);
            context.SaveChanges();
        }

        return Task.CompletedTask;
    }
}