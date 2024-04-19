using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.CQRS;

namespace Admin.Teacher.Teacher.Query.GetAllSubjectAndStudent;

public class GetAllSubjectAndStudentQuery: IQuery
{

    public Guid Id {get;set;}



}
