using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

    public class SubjectSeeder
    {


            public static Task SeedData(ApplicationDbContext context){


                if(!context.Subjects.Any()){

                    var classIds=context.Classes.Select(x=>x.Id).ToList();
                    var Subject=SubjectFaker.GetFaker(classIds).Generate(20);
                    context.Subjects.AddRange(Subject);
                    context.SaveChanges();
                }

                return Task.CompletedTask;


            }

    }
