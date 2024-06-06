using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.ClassRoom.Subject.Query.Get;

public class GetSubjectDetailQuery: IQuery
{

    public Guid YearId{get;set;}


    public Guid SubjectId{get;set;}


}
