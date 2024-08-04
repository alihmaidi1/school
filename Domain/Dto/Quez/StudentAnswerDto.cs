using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Quez;

public class StudentAnswerDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public string StartAt{get;set;}
    public DateTimeOffset EndAt{get;set;}

    public List<Question> Questions{get;set;}


    public class Question{


        public Guid Id{get;set;}

        public string? Name{get;set;}


        public float Score{get;set;}
        public string? Image{get;set;}
        public List<Answer> Answers{get;set;}

    }

    public class Answer{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public bool IsCorrect{get;set;}


        public bool IsSelect{get;set;}

    }

}
