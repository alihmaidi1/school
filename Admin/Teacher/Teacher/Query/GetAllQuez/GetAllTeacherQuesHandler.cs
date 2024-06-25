using Common.CQRS;
using Dto.Admin.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
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

        var Result=_context
        .SubjectYears
        .Where(x=>x.TeacherSubject.TeacherId==request.Id)
        .Where(x=>x.ClassYear.YearId==request.YearId)
        .Where(x=>x.TeacherSubject.Subject.Name.Contains(request.Search??""))
        .Select(x=>new GetAllTeacherQuezDto(){
            Id=x.TeacherSubject.Subject.Id,
            Name=x.TeacherSubject.Subject.Name,            
            Quezies=x.Quezs.Select(y=>new GetAllTeacherQuezDto.Quez(){
                Id=y.Id,
                Name=y.Name,
                StartAt=y.StartAt,
                EndAt=y.EndAt,
                QuestionNumber=y.Questions.Count(),
                Student=y.StudentQuezs.Count()
            }).ToList()            
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Result,"this is all your data");

    }
}
