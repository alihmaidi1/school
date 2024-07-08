using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query.GetUnSignedSubject;

public class GetUnsignedSubjectHandler : OperationResult,IQueryHandler<GetUnSignedSubjectQuery>
{

    private ApplicationDbContext _context;
    public GetUnsignedSubjectHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetUnSignedSubjectQuery request, CancellationToken cancellationToken)
    {

        var Subjects=_context
        .SubjectYears
        .Include(x=>x.Teacher)
        .Where(x=>x.Teacher==null)
        .Select(x=>new GetAllSubjectNameDto{

            Id=x.Id,
            Name=x.Subject.Name
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Subjects,"this is all subject without teacher");
    }
}