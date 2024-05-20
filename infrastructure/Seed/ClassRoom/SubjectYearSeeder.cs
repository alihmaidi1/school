using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.ClassRoom;
using Org.BouncyCastle.Math.EC.Rfc7748;

namespace infrastructure.Seed.ClassRoom;

    public class SubjectYearSeeder
    {


            public static Task SeedData(ApplicationDbContext context){

                if(!context.SubjectYears.Any()){


                // var Teachers=context.Teachers.Where(x=>x.Email=="teacher@gmail.com").Select(x=>x.Id).ToList();
                // var Years=context.Years.Select(x=>x.Id).ToList();
                // var Subjects=context.Subjects.Select(x=>x.Id).ToList();
                // // var SubjectYears=SubjectYearFaker.GetFaker(Years,Subjects,Teachers).Generate(200).DistinctBy(x=>new {x.SubjectId,x.YearId,x.TeacherId});
                // context.SubjectYears.AddRange(SubjectYears);
                // context.SaveChanges();

                }
                                
                return Task.CompletedTask;
            }

    }
