using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Warning;
using Shared.OperationResult;

namespace Admin.Teacher.Warning.Query.GetAll;

public class GetAllWarningHandler:OperationResult,
    ICommandHandler<GetAllWarningAdminQuery>
{
    private IWarningRepository WarningRepository;

    public GetAllWarningHandler(IWarningRepository WarningRepository)
    {
        this.WarningRepository = WarningRepository;
    }
    public async wiTask<JsonResult> Handle(GetAllWarningAdminQuery request, CancellationToken cancellationToken)
    {
        var Result = WarningRepository.GetAll(request.Date,request.TeacherId,request.PageNumber,request.PageSize);

        return Success(Result,"this is all warning");
    }
}