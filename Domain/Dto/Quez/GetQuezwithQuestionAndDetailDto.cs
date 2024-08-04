using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Quez;

public class GetQuezwithQuestionAndDetailDto
{


    public List<Question> Questions{get;set;}

    public Guid Id{get;set;}

    public string Name{get;set;}


    public DateTimeOffset StartAt{get;set;}
    public DateTimeOffset EndAt{get;set;}


    public List<Student> Students{get;set;}

    public class Student{

        public Guid Id{get;set;}

        public Guid StudentQuezId{get;set;}
        public string Name{get;set;}

        public string Image{get;set;}


        public string Hash{get;set;}

        public float Precent{get;set;}


    }

    

    


    


    
    public class Question{


        public Guid Id{get;set;}

        public string Name{get;set;}


        public float Score{get;set;}

        public List<Answer> Answers{get;set;}



    }


    public class Answer{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public bool IsCorrect{get;set;}

    }

}
