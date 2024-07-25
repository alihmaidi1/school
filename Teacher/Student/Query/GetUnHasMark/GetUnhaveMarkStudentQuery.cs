using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Teacher.Student.Query.GetUnHasMark;

public class GetUnhaveMarkStudentQuery: IQuery
{



    public Guid SubjectId{get;set;}


}
