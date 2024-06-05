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


                var Classyears=context.ClassYears.Select(x=>x.Id).ToList();
                var teacherSubjects=context.TeacherSubjects.Select(x=>x.Id).ToList();
                var SubjectYears=SubjectYearFaker.GetFaker(Classyears,teacherSubjects).Generate(100).DistinctBy(x=>new {x.TeacherSubjectId,x.ClassYearId});
                context.SubjectYears.AddRange(SubjectYears);
                context.SaveChanges();

                }
                                
                return Task.CompletedTask;
            }

    }
