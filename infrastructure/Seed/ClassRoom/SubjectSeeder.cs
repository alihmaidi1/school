using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

    public class SubjectSeeder
    {


            public static Task SeedData(ApplicationDbContext context){


                if(!context.Subjects.Any()){

                    var classIds=context.Classes.Select(x=>x.Id).ToList();
                    var Subjects=new List<Subject>();
                    classIds.ForEach(x=>{

                        Subjects.AddRange(SubjectFaker.GetFaker(x).Generate(5));

                    }); 
                    context.Subjects.AddRange(Subjects);
                    context.SaveChanges();
                }

                return Task.CompletedTask;


            }

    }
