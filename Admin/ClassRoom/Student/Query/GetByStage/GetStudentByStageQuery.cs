using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Shared.Abstraction;

namespace Admin.ClassRoom.Student.Query.GetByStage;

public class GetStudentByStageQuery: PaginationRequest,IQuery
{

    public Guid Id {get;set;}



}
