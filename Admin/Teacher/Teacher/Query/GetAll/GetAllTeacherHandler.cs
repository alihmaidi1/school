using Admin.Manager.Admin.Query.Get;
using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Teacher;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAll;

public class GetAllTeacherHandler:OperationResult,IQueryHandler<GetAllTeacherQuery>
{
    
    
    private ITeacherRepository _teacherRepository;

    public GetAllTeacherHandler(ITeacherRepository TeacherRepository)
    {

        _teacherRepository = TeacherRepository;

    }
    public async Task<JsonResult> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
    {
        var Result=_teacherRepository.GetAllTecher(request.PageNumber, request.PageSize,request.Search);
        return Success(Result,"this is all teacher");
        
    }
}