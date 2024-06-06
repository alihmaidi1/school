using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure.Data.ClassRoom;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Seed.ClassRoom;

public static class ClassYearSeeder
{
    
    public static Task SeedData(ApplicationDbContext context){

        if(!context.ClassYears.Any()){

            var Years=context.Years.Select(x=>x.Id).ToList();
            var Classes=context.Classes.ToList();        
            var ClassYears=new List<ClassYear>();
            Classes.ForEach(x=>{

                var classes=ClassYearFaker.GetFaker(Years,x).Generate(5).DistinctBy(x=>new {x.YearId,x.ClassId}).ToList();
                var active=classes.First();
                active.Status=true;
                classes.RemoveAt(0);
                classes.Add(active);
                ClassYears.AddRange(classes);
                

            });  
                 
            context.ClassYears.AddRange(ClassYears);
            context.SaveChanges();
        }

        return Task.CompletedTask;
    }
}