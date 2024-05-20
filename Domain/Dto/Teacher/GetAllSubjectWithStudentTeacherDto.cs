using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Teacher;

public class GetAllSubjectWithStudentTeacherDto
{
    public Guid Id{get;set;}

    public string Name{get;set;}
    public List<string> Students{get;set;}

    public class Student{

        public Guid Id{get;set;}

        public string Name{get;set;}

    }

}
