using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Student.Query.GetStudentHaveSubject;

public class GetStudentHaveSubjectQuery: IQuery
{

    public Guid SubjectId{get;set;}
    

}
