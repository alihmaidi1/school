using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Quez;
using Dto.Quez;

namespace infrastructure.Data.Quez;

public class StudentAnswerFaker
{


    public static Faker<StudentAnswer> GetFaker(List<GetQuezWithAnswerIds> GetQuezWithAnswerIds)
    {

        var StudentAnswer=new Faker<StudentAnswer>();
        StudentAnswer.RuleFor(x=>x.AnswerId,setter=>setter.PickRandom(GetQuezWithAnswerIds).Id);
        StudentAnswer.RuleFor(x=>x.StudentQuizId,(setter,StudentAnswer)=>setter.PickRandom(GetQuezWithAnswerIds.First(x=>x.Id==StudentAnswer.AnswerId).Answers));
        return StudentAnswer;

    }

}
