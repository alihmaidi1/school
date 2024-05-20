using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Dto.ClassRoom.Subject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetAll;

public class GetAllSubjectHandler : OperationResult, ICommandHandler<GetAllSubjectCommand>
{

    private ApplicationDbContext _context;

    public GetAllSubjectHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllSubjectCommand request, CancellationToken cancellationToken)
    {


        return null;
        // var Subjects=_context
        // .Subjects
        // .Where(x=>x.Name.Equals(request.Search??"")||x.Class.Name.Equals(request.Search??""))
        // .Select(x=>new GetAllSubjectDto{

        //     Id=x.Id,
        //     SubjectName=x.Name,
        //     Year=x.Class.Name,
        //     Degree=x.Degree,
        //     MinDegree=x.MinDegree,
        //     Status=x.SubjectYears.Any(x=>x.Year.Date==DateTime.Now)

        // }).ToPagedList(request.PageNumber,request.PageSize);

        // return Success(Subjects,"this is all subject");   
    }
}
