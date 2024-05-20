using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllTeacherStudentSubject;

public class GetAllTeacherStudentSubjectQuery: IQuery
{

    public Guid YearId{get;set;}

    public Guid TeacherId{get;set;}

}
