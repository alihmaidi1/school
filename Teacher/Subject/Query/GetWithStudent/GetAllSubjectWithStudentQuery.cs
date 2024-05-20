using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Subject.Query.GetWithStudent;

public class GetAllSubjectWithStudentQuery: IQuery
{

    public Guid YearId{get;set;}

}
