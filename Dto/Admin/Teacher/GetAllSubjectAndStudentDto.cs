using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.Admin.Teacher;

public class GetAllSubjectAndStudentDto
{

    public Guid Id {get;set;}

    public string Name{get;set;}


    public string Email {get;set;}

    public string Image{get;set;}

    public string Hash{get;set;}


    public List<Subject> Subjects{get;set;}


    public class Year{


        public Guid Id {get;set;}


        public string Name{get;set;}



        public List<Student> Students{get;set;}

    }

    public class Subject{

        public Guid Id {get;set;}
        public string Name{get;set;}

        public List<Year> Years{get;set;}

        
    }

    public class Student{


        public Guid Id {get;set;}


        public float Mark{get;set;}

        public string Name{get;set;}
    
    }





}
