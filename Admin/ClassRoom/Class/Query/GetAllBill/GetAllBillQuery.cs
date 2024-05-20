using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.ClassRoom.Class.Query.GetAllBill;

public class GetAllBillQuery: PaginationRequest ,IQuery
{

    public Guid YearId{get;set;}


    public Guid ClassId{get;set;}    

}
