using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

public class TeacherSubjectSeeder
{

    public static Task SeedData(ApplicationDbContext context){

            if(!context.TeacherSubjects.Any()){

                var Subjects=context.Subjects.Select(x=>x.Id).ToList();
                var Teachers=context.Teachers.Select(x=>x.Id).ToList();

                var TeacherSubjects=TeacherSubjectFaker.GetFaker(Subjects,Teachers).Generate(40).DistinctBy(x=>new {x.SubjectId,x.TeacherId});
                context.TeacherSubjects.AddRange(TeacherSubjects);
                context.SaveChanges();

            }
            return Task.CompletedTask;

    }

}
