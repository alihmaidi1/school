using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllSubject;

public class GetAllSubjectQuery: IQuery
{

    public Guid SubjectId{get;set;}

}
