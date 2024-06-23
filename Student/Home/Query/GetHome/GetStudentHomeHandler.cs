using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.OperationResult;
using Shared.Services.User;

namespace Student.Home.Query.GetHome;

public class GetStudentHomeHandler : OperationResult,IQueryHandler<GetStudentHomeQuery>
{


    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetStudentHomeHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }


    public async Task<JsonResult> Handle(GetStudentHomeQuery request, CancellationToken cancellationToken)
    {
        var Home=new GetStudentHomeDto();
        Home.Banners=_context
        .Banners
        .AsNoTracking()
        .Where(x=>x.StartAt<=DateTimeOffset.UtcNow)
        .Where(x=>x.EndAt>=DateTimeOffset.UtcNow)
        .Select(x=>new GetAllBannerDto{

            Id=x.Id,
            Image=x.Image,
            Url=x.Url,
            StartAt=x.StartAt,
            EndAt=x.EndAt,
            Name=x.Name


        })
        .ToList();

        Home.Subjects=_context
        .StudentSubjects
        .AsNoTracking()
        .Where(x=>x.StudentId==_currentUserService.GetUserid())
        .Where(x=>x.SubjectYear.ClassYear.Status)
        .Select(x=>new GetStudentHomeDto.Subject{


            Id=x.SubjectYear.Id,
            Name=x.SubjectYear.TeacherSubject.Subject.Name


        })
        .ToList();

        return Success(Home);
    }
}
