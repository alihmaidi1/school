using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using Dto.Quez;
using infrastructure.Data.Quez;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Seed.Quez;

public class StudentAnswerSeeder
{

    public static async Task seedData(ApplicationDbContext context){


        if(!context.StudentAnswers.Any()){

            List<StudentAnswer> StudentAnswers=new List<StudentAnswer>();
            var Quez=context
            .StudentQuezs
            .Where(x=>x.Quez.StartAt>DateTimeOffset.UtcNow)
            .Select(x=>new {

                Id=x.Id,
                Answer=x.Quez.Questions.Select(x=>x.Answers).ToList()
            }).ToList();

            Quez.ForEach(x=>{


                StudentAnswers.AddRange(
                    x
                    .Answer
                    .Select(y=>new StudentAnswer{
                        StudentQuizId=x.Id,
                        AnswerId=y.OrderBy(z=>Guid.NewGuid()).First().Id
                    
                    })
                    .ToList()
                );

            });

            // var StudentAnswer=StudentAnswerFaker.GetFaker(Quez).Generate(100).DistinctBy(x=>new {x.StudentQuizId,x.AnswerId});
            context.StudentAnswers.AddRange(StudentAnswers);
            context.SaveChanges();
        }


    }


}
