using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.Services.User;

namespace Parent.Student.Query.GetStudentMarks;

public class GetParentStudentMarksHandler : OperationResult,IQueryHandler<GetParentStudentMarksQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetParentStudentMarksHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(GetParentStudentMarksQuery request, CancellationToken cancellationToken)
    {

        var ChildFilter=request.Childs?.Any()??false;
        var Marks=
        _context
        .Students
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.ParentId==_currentUserService.GetUserid())
        .Where(x=>ChildFilter?request.Childs!.Contains(x.Id):true)
        .Select(x=>new GetParentStudentMarksDto{

            Id=x.Id,
            Name=x.Name,
            Marks=x
            .StudentQuezs
            .Where(x=>x.Quez.SubjectYear.ClassYear.Status)
            .GroupBy(x=>x.Quez.SubjectYear.TeacherSubject.Subject)
            .Select(y=>new GetParentStudentMarksDto.Subject{
                
                Id=y.Key.Id,
                SubjectName=y.Key.Name,
                Quezs=y.Select(z=>new GetParentStudentMarksDto.Quez{

                    Id=z.QuezId,
                    Name=z.Quez.Name,
                    Mark=z.StudentAnswers.Select(x=>x.Answer.Question.Score).Sum()/z.Quez.Questions.Sum(x=>x.Score)

                }).ToList()

            }).ToList()
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Marks);
    }
}
