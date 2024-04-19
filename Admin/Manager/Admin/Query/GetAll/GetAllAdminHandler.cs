using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Admin;
using Shared.OperationResult;

namespace Admin.Manager.Admin.Query.GetAll;

public class GetAllAdminHandler:OperationResult,IQueryHandler<GetAllAdminQuery>
{
    
    private readonly IAdminRepository _adminRepository;

    public GetAllAdminHandler(IAdminRepository adminRepository)
    {
        this._adminRepository = adminRepository;
    }
    
    public async Task<JsonResult> Handle(GetAllAdminQuery request, CancellationToken cancellationToken)
    {
        
        var result = _adminRepository.GetAll(request.OrderBy, request.PageNumber, request.PageSize,request.Search);
        return Success(result, "this is all admin");
    }
}