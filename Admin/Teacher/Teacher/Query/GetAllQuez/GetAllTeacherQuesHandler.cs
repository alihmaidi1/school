using System.Data.Entity;
using Common.CQRS;
using Dto.Admin.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAllQuez;

public class GetAllTeacherQuesHandler : OperationResult, IQueryHandler<GetAllTeacherQuezQuery>
{

    private readonly ApplicationDbContext _context;
    public GetAllTeacherQuesHandler(ApplicationDbContext context){


        _context=context;


    }
    public async Task<JsonResult> Handle(GetAllTeacherQuezQuery request, CancellationToken cancellationToken)
    {

        var Result=_context.SubjectYears.AsNoTracking();
        if(request.YearId.HasValue){
    
            Result=Result.Where(x=>x.ClassYear.YearId==request.YearId);
        }else{

            Result=Result.Where(x=>x.ClassYear.Status);
        }
        var Result1=Result.Where(x=>x.TeacherId==request.Id)
        .Select(x=>new GetAllTeacherQuezDto(){
            Id=x.Subject.Id,
            Name=x.Subject.Name,            
            Quezies=x.Quezs.Select(y=>new GetAllTeacherQuezDto.Quez(){
                Id=y.Id,
                Name=y.Name,
                Status=y.EndAt<DateTime.UtcNow,
                StartAt=y.StartAt,
                EndAt=y.EndAt,
                QuestionNumber=y.Questions.Count(),
                Student=y.StudentQuezs.Count()
            }).ToList()            
        })
        .ToList();
        return Success(Result1,"this is all your data");

    }
}
