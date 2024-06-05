using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetStudentMarkInQuez;

public class GetStudentMarkInQuezQuery: IQuery
{


    public Guid Id{get;set;}

}
