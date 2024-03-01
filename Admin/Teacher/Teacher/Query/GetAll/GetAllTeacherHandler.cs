using Admin.Manager.Admin.Query.Get;
using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Teacher;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Query.GetAll;

public class GetAllTeacherHandler:OperationResult,
    IQueryHandler<GetAllTeacherQuery>
{
    
    
    private ITeacherRepository TeacherRepository;

    public GetAllTeacherHandler(ITeacherRepository TeacherRepository)
    {

        this.TeacherRepository = TeacherRepository;

    }
    public async Task<JsonResult> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
    {
        var Result=TeacherRepository.GetAllTecher(request.OrderBy, request.PageNumber, request.PageSize);
        return Success(Result,"this is all teacher");
        
    }
}