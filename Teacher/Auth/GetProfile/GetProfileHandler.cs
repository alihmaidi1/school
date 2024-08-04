using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Auth.GetProfile;

public class GetProfileHandler : OperationResult,IQueryHandler<GetProfileQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetProfileHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    public async Task<JsonResult> Handle(GetProfileQuery request, CancellationToken cancellationToken)
    {

        var Teacher=_context
        .Teachers
        .AsNoTracking()
        .Select(x=>new GetAllTeacherDto{

            Id = x.Id,
            Name = x.Name,
            Email = x.Email,
            Image = x.Image,
            SubjectIds=x.TeacherSubjects.Select(x=>x.SubjectId).ToList(),
            Hash = x.Hash,
            StudentNumber=x.SubjectYears.Where(x=>x.DateDeleted==null).Where(x=>x.ClassYear.Status).SelectMany(x=>x.StudentSubjects.Where(x=>x.DateDeleted==null)).Distinct().Count(),
            SubjectNumber=x.TeacherSubjects.Where(x=>x.DateDeleted==null).Count()            




        })
        .First(x=>x.Id==_currentUserService.GetUserid());

        return Success(Teacher);

    }
}
