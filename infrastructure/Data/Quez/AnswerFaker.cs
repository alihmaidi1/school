using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Quez;

namespace infrastructure.Data.Quez;

public class AnswerFaker
{


    public static Faker<Answer> GetFaker()
    {

        var Answer=new Faker<Answer>();
        Answer.RuleFor(x=>x.Name,setter=>setter.Random.Words(2));
        Answer.RuleFor(x=>x.IsCorrect,setter=>setter.Random.Bool());
        return Answer;
        

    }

}
