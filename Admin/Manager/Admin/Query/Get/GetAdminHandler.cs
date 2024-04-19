using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Admin;
using Shared.OperationResult;

namespace Admin.Manager.Admin.Query.Get;

public class GetAdminHandler:OperationResult,
    IQueryHandler<GetAdminQuery>
{
    
    private readonly IAdminRepository adminRepository;

    public GetAdminHandler(IAdminRepository adminRepository)
    {
        this.adminRepository = adminRepository;
    }
    
    public async Task<JsonResult> Handle(GetAdminQuery request, CancellationToken cancellationToken)
    {

        var result=adminRepository.GetInfo(request.id);
        return Success(result, "this is all admin");

    }
}