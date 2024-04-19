using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllLeson;

public class GetAllTeacherLesonQuery: IQuery
{

    public Guid Id{get;set;}


    public Guid YearId{get;set;}




}
