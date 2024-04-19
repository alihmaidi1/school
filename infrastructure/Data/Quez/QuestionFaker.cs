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
        Question.RuleFor(x=>x.Answers,setter=>AnswerFaker.GetFaker().Generate(setter.Random.Int(50,100)));
        return Question;

    }

}
