using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.Student.Student.Query.GetAllInstallment;

public class GetAllInstallmentQuery: PaginationRequest,IQuery
{


    public Guid Id{get;set;}


    

}
