using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.OperationResult;

namespace Admin.Manager.Role.Query.GetAll;

public class GetAllRoleHandler:OperationResult,IQueryHandler<GetRolesQuery>

{
    private readonly IRoleRepository roleRepository;

    
    
    public GetAllRoleHandler(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }
    
    public async Task<JsonResult> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var Result = roleRepository.GetAll(request.PageNumber, request.PageSize,request.Search);
        return Success(Result, "this is all role");

    }
}