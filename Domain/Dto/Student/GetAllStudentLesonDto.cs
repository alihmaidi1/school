using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Entity.EntityOperation;

namespace Domain.Dto.Student;


public class GetAllStudentLesonDto
{

    public int LesonCount{get;set;}

    public int QuezCount{get;set;}

    public int StudentCount{get;set;}

    public List<Leson> Lesons{get;set;}


    public class Leson{

        public Guid Id{get;set;}


        public string Name{get;set;}

        public string Url{get;set;}
    }

}
