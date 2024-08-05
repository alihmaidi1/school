using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Parent.GetAllParentOrStudent;

public class GetAllParentOrStudentQuery: IQuery
{

    public bool Status{get;set;}

}
