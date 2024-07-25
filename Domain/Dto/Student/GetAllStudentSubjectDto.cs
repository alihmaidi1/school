using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class GetAllStudentSubjectDto
{

    public Guid Id{get;set;}

    public string Name{get;set;}

    public float? Degree{get;set;}

}
