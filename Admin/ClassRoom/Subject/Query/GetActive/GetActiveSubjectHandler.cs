using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Admin.ClassRoom.Subject.Query.GetActive;
public class GetActiveSubjectHandler : OperationResult,IQueryHandler<GetActiveSubjectQuery>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public GetActiveSubjectHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetActiveSubjectQuery request, CancellationToken cancellationToken)
    {


        var Subjects=_context.SubjectYears.AsNoTracking().Where(x=>x.ClassYear.Status);


        Subjects=Subjects.Where(x=>x.TeacherId==request.Id);


        var result=Subjects.Select(x=>new GetAllSubjectNameDto{

            Id=x.Subject.Id,
            Name=x.Subject.Name

        }).ToList();

        return Success(result);
    }
}
