using Common.CQRS;
using Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.OperationResult;

namespace Admin.Manager.Role.Query.Get;

public class GetManagersByRoleHanlder:OperationResult,
    IQueryHandler<GetManagerByRoleQuery>

{

    private readonly IRoleRepository roleRepository;


    public GetManagersByRoleHanlder(IRoleRepository roleRepository)
    {

        this.roleRepository = roleRepository;
    }

    
    public async Task<JsonResult> Handle(GetManagerByRoleQuery request, CancellationToken cancellationToken)
    {

        var Result = roleRepository.GetAdminById(new RoleID(request.Id), request.OrderBy, request.PageNumber, request.PageSize);
        return Success(Result, "this is all admin");
        
    }
}