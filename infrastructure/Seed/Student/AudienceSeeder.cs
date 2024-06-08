using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Dto.Student;
using Domain.Entities.Student.Audience;

namespace infrastructure.Seed.Student;

public static class AudienceSeeder
{

    public static async Task seedData(ApplicationDbContext context)
    {


        if (!context.Audiences.Any())
        {

            var SubjectYears=context
            .SubjectYears
            .Select(x=>new SubjectYearWithStudentIdsDto{
                Id=x.Id,
                StudentsId=x.StudentSubjects.Select(x=>x.StudentId).Distinct().ToList()

            })
            .ToList();

            var Audiences=new List<Audience>();
            var Faker=new Faker();
            SubjectYears.ForEach(x=>{


                for (int i = 0; i < 6; i++)
                {
                    int SessionNumber=Faker.Random.Int(1,50);
                bool IsExists=Faker.Random.Bool();
                DateTimeOffset date=Faker.Date.BetweenOffset(DateTimeOffset.UtcNow.AddMonths(-5),DateTimeOffset.UtcNow);
                x.StudentsId.ForEach(y=>{
                    
                    Audiences.Add(new Audience{

                        SessionNumber=SessionNumber,
                        IsExists=IsExists,
                        SubjectYearId=x.Id,
                        StudentId=y,
                        Date=date
                        
                    });

                });

                    
                }
                
            });

            Audiences=Audiences.DistinctBy(x=>new {x.StudentId,x.SubjectYearId,x.SessionNumber}).ToList();
            context.Audiences.AddRange(Audiences);
            context.SaveChanges();
        }

    }

}
