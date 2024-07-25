using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.ClassRoom.Subject.Query.GetAllByYear;

public class GetAllSubjectByYearQuery: PaginationRequest ,IQuery
{


        public Guid? YearId{get;set;}



        public string? Search{get;set;}

}
