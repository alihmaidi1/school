using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class GetQuezInfoDto
{

    public string Name{get;set;}

    
    public List<Question> Quezs{get;set;}
    public class Question{

        public Guid Id{get;set;}

        public string Name{get;set;}

        public int Time{get;set;}

        public string Image{get;set;}

        public List<Answer> Answers{get;set;}

    }


    public class Answer{


        public Guid Id{get;set;}

        public string Name{get;set;}

    }

}
