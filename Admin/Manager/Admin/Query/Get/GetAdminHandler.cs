using Admin.Admin.Query.GetAll;
using Common.CQRS;
using Domain.Entities.Manager.Admin;
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

        var Result = adminRepository.GetInfo(new AdminID(request.id));
        return Success(Result,"this is admin info");
        throw new NotImplementedException();
    }
}