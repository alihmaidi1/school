using Common.CQRS;
using Domain.Dto.Parent;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;
using Shared.OperationResult.MethodExtension;
using Shared.Services.User;

namespace Parent.Student.Query.FinalResult;

public class GetParentFinalResultHandler : OperationResult,IQueryHandler<GetParentFinalResultQuery>
{

    private ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public GetParentFinalResultHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;
    }
    public async Task<JsonResult> Handle(GetParentFinalResultQuery request, CancellationToken cancellationToken)
    {
        var ChildFilter=request.Childs?.Any()??false;
        var Results=_context
        .Students
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>x.ParentId==_currentUserService.UserId)
        .Where(x=>ChildFilter?request.Childs!.Contains(x.Id):true)        
        .Select(x=>new GetAllStudentResultDto{
            Id=x.Id,
            Name=x.Name,
            Results=x
                .StudentSubjects
                .Where(x=>!x.SubjectYear.ClassYear.Status)
                .GroupBy(x=>x.SubjectYear.ClassYear)
                .Select(y=>new GetAllStudentResultDto.Result{

                    Date=y.Key.Year.Date,
                    Total=y.Select(x=>x.Mark??0).Sum()/y.Count(),
                    Marks=y.Select(z=>new GetAllStudentResultDto.SubjectMark{

                        Mark=z.Mark??0,
                        Name=z.SubjectYear.TeacherSubject.Subject.Name

                    }).ToList()

                    

                }).ToList()
                

        })
        .ToPagedList(request.PageNumber,request.PageSize);


        return Success(Results);
        
    }
}
