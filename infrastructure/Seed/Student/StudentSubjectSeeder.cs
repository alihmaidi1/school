using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure.Data.Student;

namespace infrastructure.Seed.Student;

public class StudentSubjectSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {


        if(!context.StudentSubjects.Any()){


            var Students=context.Students.Select(x=>x.Id).ToList();
            var SubjectYears=context.SubjectYears.Select(x=>x.Id).ToList();
            var StudentSubject=StudentSubjectFaker.GetFaker(Students,SubjectYears).Generate(100).DistinctBy(x=>new {x.StudentId,x.SubjectYearId});
            context.StudentSubjects.AddRange(StudentSubject);
            context.SaveChanges();
        }


    }

}
