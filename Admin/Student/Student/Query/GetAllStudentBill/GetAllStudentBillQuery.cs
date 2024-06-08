using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Student.Student.Query.GetAllStudentBill;

public class GetAllStudentBillQuery: IQuery
{

    public Guid StudentId{get;set;}

    public Guid YearId{get;set;}

    public Guid ClassId{get;set;}


}
