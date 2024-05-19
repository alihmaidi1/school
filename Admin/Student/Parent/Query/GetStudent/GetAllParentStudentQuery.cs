using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Student.Parent.Query.GetStudent;

public class GetAllParentStudentQuery: IQuery
{

    public Guid Id{get;set;}

}
