using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain.Entities.Quez;

namespace infrastructure.Data.Quez;

public class QuestionFaker
{


    public static Faker<Question> GetFaker()
    {

        

        var Question=new Faker<Question>();
        Question.RuleFor(x=>x.Name,setter=>setter.Random.Words(1));
        Question.RuleFor(x=>x.Answers,setter=>AnswerFaker.GetFaker().Generate(setter.Random.Int(2,4)));
        Question.RuleFor(x=>x.Time,setter=>setter.Random.Int(60,120));
        Question.RuleFor(x=>x.Score,setter=>setter.Random.Int(1,3));
        return Question;

    }

}
