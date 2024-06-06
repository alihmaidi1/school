using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher;
using infrastructure.Data.ClassRoom;

namespace infrastructure.Seed.ClassRoom;

public class TeacherSubjectSeeder
{

    public static Task SeedData(ApplicationDbContext context){


        List<Guid> Subjects=context
        .Subjects
        .Where(x=>!x.TeacherSubjects.Any())
        .Select(x=>x.Id)
        .ToList();                


        var Teachers=context.Teachers.Select(x=>x.Id).ToList();
        var TeacherSubjects=new List<TeacherSubject>();
        Subjects.ForEach(x=>{

            TeacherSubjects.Add(new TeacherSubject{

                SubjectId=x,
                TeacherId=Teachers.OrderBy(x=>Guid.NewGuid()).First()
            });

        });

        context.AddRange(TeacherSubjects);
        context.SaveChanges();
        return Task.CompletedTask;

    }

}
