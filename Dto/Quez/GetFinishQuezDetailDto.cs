using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Dto.Quez;

public class GetFinishQuezDetailDto
{

    public Guid Id{get;set;}


    public string Name{get;set;}

    public DateTimeOffset StartAt{get;set;}

    public List<Student> Students{get;set;}


    public class Student{


        public Guid Id{get;set;}

        public string Name{get;set;}

        public string? Image{get;set;}
        public string? Hash{get;set;}

        public float Precent{get;set;} 
    }

}
