using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.EntityOperation;

namespace Domain.Dto.Student;

public class GetAllStudentQuezDto
{

    public int LesonCount{get;set;}

    public int QuezCount{get;set;}

    public int StudentCount{get;set;}


    public List<Quez> Quezs{get;set;}

    public class Quez{


        public Guid Id{get;set;}

        public DateTimeOffset StartAt{get;set;}
        public DateTimeOffset EndAt{get;set;}

        public int QuestionNumber{get;set;}

        public string Name{get;set;}

    }


}
