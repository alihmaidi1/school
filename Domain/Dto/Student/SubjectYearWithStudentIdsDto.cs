using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Dto.Student;

public class SubjectYearWithStudentIdsDto
{

    public Guid Id{get;set;}

    public List<Guid> StudentsId{get;set;}

}
