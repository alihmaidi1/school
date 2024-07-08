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

        var Results=_context
        .Students
        .AsNoTracking()
        .Where(x=>x.Id==request.StudentId)    
        .Select(x=>new GetAllStudentResultDto{
            Id=x.Id,
            Name=x.Name,
            Results=x
                .StudentSubjects
                .Where(x=>!x.SubjectYear.ClassYear.Status)
                .GroupBy(x=>x.SubjectYear.ClassYear.Year)
                .Select(y=>new GetAllStudentResultDto.Result{

                    Date=y.Key.Date,
                    Total=y.Select(x=>x.Mark??0).Sum()/y.Count(),
                    Marks=y.Select(z=>new GetAllStudentResultDto.SubjectMark{

                        Mark=z.Mark??0,
                        Name=z.SubjectYear.Subject.Name

                    }).ToList()

                    

                }).ToList()
                

        })
        .First();


        return Success(Results);
        
    }
}
