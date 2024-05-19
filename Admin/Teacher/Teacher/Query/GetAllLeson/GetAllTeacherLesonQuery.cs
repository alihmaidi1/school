using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.Teacher.Teacher.Query.GetAllLeson;

public class GetAllTeacherLesonQuery: PaginationRequest, IQuery
{

    public Guid Id{get;set;}


    public Guid YearId{get;set;}




}
