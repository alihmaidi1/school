using System.Security.Claims;
using Common.CQRS;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Warning;
using Shared.OperationResult;

namespace Teacher.Warning.Query.GetAll;

public class WarningQueryHandler:OperationResult,
    IQueryHandler<GetWarningQuery>
{
    
    
    private IHttpContextAccessor HttpContextAccessor;
    // private IWarningRepository warningRepository;

    public WarningQueryHandler(IHttpContextAccessor HttpContextAccessor)
    {

        this.HttpContextAccessor = HttpContextAccessor;


    } 
    
    public async Task<JsonResult> Handle(GetWarningQuery request, CancellationToken cancellationToken)
    {
        return null;
        // var teacherId = HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier).Value;
        // var Result=warningRepository.GetAll(new Guid(teacherId),request.PageNumber,request.PageSize);
        // return Success(Result,"this is all your warnings");
    }
}