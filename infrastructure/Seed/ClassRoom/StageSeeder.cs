using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

public static class StageSeeder
{

    public static Task SeedData(ApplicationDbContext context){


            if(!context.Stages.Any()){


                var Stages=new List<Stage>();
                Stages.Add(new Stage(){

                    Name="Primary stage",
                    Classes=new List<Class>(){new Class(){ Name="first class"},new Class{Name="second class"},new Class{Name="third class"}}
                });


                Stages.Add(new Stage(){

                    Name="2th stage",
                    Classes=new List<Class>(){new Class(){ Name="4th class"},new Class{Name="5th class"},new Class{Name="6th class"}}

                });

                Stages.Add(new Stage(){

                    Name="3th stage",
                    Classes=new List<Class>(){new Class(){ Name="7th class"},new Class{Name="8th class"},new Class{Name="9th class"}}

                });

                context.Stages.AddRange(Stages);
                context.SaveChanges();

                
            }

                return Task.CompletedTask;


    }



}
