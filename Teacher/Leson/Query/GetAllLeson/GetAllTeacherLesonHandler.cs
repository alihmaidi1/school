using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Dto.Admin.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;
using Teacher.Leson.Teacher.Leson.Query.GetAllLeson;

namespace Admin.Teacher.Teacher.Query.GetAllLeson;

public class GetAllTeacherLesonHandler : OperationResult,IQueryHandler<GetAllLesonQuery>
{

    public ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public GetAllTeacherLesonHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }

    public async Task<JsonResult> Handle(GetAllLesonQuery request, CancellationToken cancellationToken)
    {

        var Lesons=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.ClassYear.YearId==request.YearId)
        .Where(x=>x.TeacherSubject.TeacherId==_currentUserService.GetUserid())
        .Select(x=>new GetAllTeacherLesonDto(){            
            Id=x.TeacherSubject.Subject.Id,
            Name=x.TeacherSubject.Subject.Name,
            Lesons=x.Lesons.Select(y=>new GetAllTeacherLesonDto.Leson(){
                Id=y.Id,
                Name=y.Name,
                Url=y.Url

            }).ToList()
        })
        .ToList();
        return Success(Lesons,"this is all your data");

    }
}
