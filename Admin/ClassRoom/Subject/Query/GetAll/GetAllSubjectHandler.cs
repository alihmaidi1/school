using Domain.Dto.ClassRoom.Subject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetAll;

public class GetAllSubjectHandler : OperationResult, ICommandHandler<GetAllSubjectCommand>
{

    private ApplicationDbContext _context;

    public GetAllSubjectHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllSubjectCommand request, CancellationToken cancellationToken)
    {

        var Subjects=_context
        .SubjectYears
        .Where(x=>x.ClassYear.Status)
        .Select(x=>new GetAllSubjectDto{

            Id=x.TeacherSubject.SubjectId,
            SubjectName=x.TeacherSubject.Subject.Name,
            Year=x.ClassYear.Class.Name,
            Degree=x.TeacherSubject.Subject.Degree,
            MinDegree=x.TeacherSubject.Subject.MinDegree,
            Status=x.TeacherSubject.Teacher==null

        }).ToPagedList(request.PageNumber,request.PageSize);
        return Success(Subjects,"this is all subject ");   
    }
}
