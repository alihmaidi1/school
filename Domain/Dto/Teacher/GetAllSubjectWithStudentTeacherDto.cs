using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Teacher;

public class GetAllSubjectWithStudentTeacherDto
{
    public Guid Id{get;set;}

    public string Name{get;set;}
    public List<Student> Students{get;set;}

    public class Student{

        public Guid Id{get;set;}

        public string Name{get;set;}

        public string Image{get;set;}
        public string hash{get;set;}

    }

}
