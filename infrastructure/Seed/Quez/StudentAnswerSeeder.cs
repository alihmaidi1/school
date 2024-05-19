using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.Quez;
using infrastructure.Data.Quez;
using Microsoft.EntityFrameworkCore;

namespace infrastructure.Seed.Quez;

public class StudentAnswerSeeder
{

    public static async Task seedData(ApplicationDbContext context){


        if(!context.StudentAnswers.Any()){

            
            // var Quez=context
            // .StudentQuezs
            // .Include(x=>x.Questions)
            // .ThenInclude(x=>x.Answers)
            // .Select(x=>new GetQuezWithAnswerIds{
            //     Id=x.Id,
            //     Answers=x.Questions.SelectMany(y=>y.Answers.Select(z=>z.Id).ToList()).ToList()
            //     })
            // .ToList();

            // var StudentAnswer=StudentAnswerFaker.GetFaker(Quez).Generate(100).DistinctBy(x=>new {x.StudentQuizId,x.AnswerId});
            // context.SaveChanges();
        }


    }


}
