using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.ClassRoom.Student.Query.GetSubjectByYear;

public class GetStudentSubjectByYearQuery: PaginationRequest ,IQuery
{


    public Guid Id{get;set;}

    public Guid YearId{get;set;}



}
