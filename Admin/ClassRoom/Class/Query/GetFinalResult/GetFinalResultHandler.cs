using System.Data.Entity;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Query;

public class GetFinalResultHandler : OperationResult ,IQueryHandler<GetFinalResultQuery>
{

    private ApplicationDbContext _context;

    public GetFinalResultHandler(ApplicationDbContext context){

        _context=context;
 
    }
    public async Task<JsonResult> Handle(GetFinalResultQuery request, CancellationToken cancellationToken)
    {

        var Result=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.ClassYear.ClassId==request.ClassId)
        .Where(x=>!x.ClassYear.Status);

        if(request.YearId.HasValue){

            Result=Result
            .Where(x=>x.ClassYear.YearId==request.YearId);

        }else{

            var LastYear=_context
            .Years
            .AsNoTracking()
            .Where(x=>x.ClassYears.Any(x=>!x.Status&&x.ClassId==request.ClassId))
            .OrderBy(x=>x.Date)
            .FirstOrDefault();
            if(LastYear is not null){

                Result=Result.Where(x=>x.ClassYear.YearId==LastYear.Id);


            }else{

                Result.Where(x=>false);
            }

        }


        var result=Result
        .SelectMany(x=>x.StudentSubjects)
        .GroupBy(x=>x.Student)
        .Select(x=>new GetAllResultDto{

            Id=x.Key.Id,
            Name=x.Key.Name,
            Status=x.Count(x=>x.Mark>x.SubjectYear.Subject.MinDegree)>2,
            Precent=x.Sum(x=>x.Mark.Value)/x.Count(),
            Subjects=x.Select(y=>new GetAllResultDto.Subject{
                Id=y.SubjectYear.SubjectId,
                Name=y.SubjectYear.Subject.Name,
                Degree=y.Mark
            }).ToList()

            

            
        })
        .ToPagedList(request.PageNumber,request.PageSize);

        return Success(result,"this is the result");
    }
}
