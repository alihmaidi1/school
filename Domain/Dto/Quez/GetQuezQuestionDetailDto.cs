using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Quez;

public class GetQuezQuestionDetailDto
{

    public Guid Id{get;set;}


    public string Name{get;set;}

    public DateTimeOffset StartAt{get;set;}

    public List<Question> Questions{get;set;}

    public class Question{


        public Guid Id{get;set;}

        public string Name{get;set;}
    }

}
