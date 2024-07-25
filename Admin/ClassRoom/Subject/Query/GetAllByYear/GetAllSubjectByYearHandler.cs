using Common.CQRS;
using Domain.Dto.ClassRoom.Subject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetAllByYear;

public class GetAllSubjectByYearHandler : OperationResult, IQueryHandler<GetAllSubjectByYearQuery>
{

    private ApplicationDbContext _context;
    public GetAllSubjectByYearHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllSubjectByYearQuery request, CancellationToken cancellationToken)
    {

        var SubjectResponse=new GetAllSubjectByYearDto(){


        };

        PageList<GetAllSubjectByYearDto.Subject> Result;

        if(!request.YearId.HasValue){

            Result=_context
            .Subjects              
            .Where(x=>x.Name.Contains(request.Search??""))  
            .Select(x=>new GetAllSubjectByYearDto.Subject{
                Id=x.Id,
                Name=x.Name,
                Year=x.Class.Name,
                Degree=x.Degree,
                MinDegree=x.MinDegree,
            }).ToPagedList(request.PageNumber,request.PageSize);

        }else{


            Result=_context
            .ClassYears        
            .Where(x=>x.YearId==request.YearId)
            .Select(x=>x.Class)
            .SelectMany(x=>x.Subjects.Where(x=>x.Name.Contains(request.Search??"")))
            .Select(x=>new GetAllSubjectByYearDto.Subject{
                Id=x.Id,
                Name=x.Name,
                Year=x.Class.Name,
                Degree=x.Degree,
                MinDegree=x.MinDegree,
            }).ToPagedList(request.PageNumber,request.PageSize);


        }
        
        SubjectResponse.Subjects=Result;
        SubjectResponse.TotalSubject=Result.Data.Count();
        SubjectResponse.TotalTeacher=_context.Teachers.Where(x=>x.Status).Count();
        return Success(SubjectResponse,"this is all subject");

    }
}
