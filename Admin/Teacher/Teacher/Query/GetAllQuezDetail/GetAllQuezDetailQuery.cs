using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllQuezDetail;

public class GetAllQuezDetailQuery:IQuery
{


    public Guid Id{get;set;}


}
