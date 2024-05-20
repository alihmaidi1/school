using Common.CQRS;
using Domain.Dto.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAllTeacherYear;

public class GetAllTeacherYearHandler : OperationResult, IQueryHandler<GetAllTeacherYearQuery>
{

    private ApplicationDbContext _context;
    public GetAllTeacherYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllTeacherYearQuery request, CancellationToken cancellationToken)
    {

        return null;
        // var years=_context
        // .Teachers
        // .Where(x=>x.Id==request.Id)
        // // .SelectMany(x=>x.SubjectYears.Select(x=>x.Year))
        // .Select(x=>new GetAllYearDto(){

        //     Id=x.Id,
        //     Name=x.Date.ToString()
        // })
        // .ToList();


        // return Success(years,"this is all teacher year in this school");
    }
}
