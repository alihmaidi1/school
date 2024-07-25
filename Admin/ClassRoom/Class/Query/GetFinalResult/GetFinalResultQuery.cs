using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.ClassRoom.Class.Query;

public class GetFinalResultQuery : PaginationRequest, IQuery
{

    public Guid ClassId{get;set;}


    public Guid? YearId{get;set;}



}
