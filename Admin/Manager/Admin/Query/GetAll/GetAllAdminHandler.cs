using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Admin;
using Shared.OperationResult;

namespace Admin.Admin.Query.GetAll;

public class GetAllAdminHandler:OperationResult,
    IQueryHandler<GetAllAdminQuery>
{
    
    private readonly IAdminRepository adminRepository;

    public GetAllAdminHandler(IAdminRepository adminRepository)
    {


        this.adminRepository = adminRepository;


    }
    
    public async Task<JsonResult> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
    {
        
        var Result = adminRepository.GetAlladmin(request.OrderBy, request.PageNumber, request.PageSize);
        return Success(Result, "this is all admin");
    }
}