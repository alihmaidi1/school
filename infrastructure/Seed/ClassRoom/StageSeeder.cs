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
                    Classes=new List<Class>(){new Class(){ Name="first class",Level=1},new Class{Name="second class",Level=2},new Class{Name="third class",Level=3}}
                });


                Stages.Add(new Stage(){

                    Name="2th stage",
                    Classes=new List<Class>(){new Class(){ Name="4th class",Level=4},new Class{Name="5th class",Level=5},new Class{Name="6th class",Level=6}}
                });

                Stages.Add(new Stage(){

                    Name="3th stage",
                    Classes=new List<Class>(){new Class(){ Name="7th class",Level=7},new Class{Name="8th class",Level=8},new Class{Name="9th class",Level=9}}

                });

                context.Stages.AddRange(Stages);
                context.SaveChanges();

                
            }

                return Task.CompletedTask;


    }



}
