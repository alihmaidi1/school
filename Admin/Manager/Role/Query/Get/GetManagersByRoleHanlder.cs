using Common.CQRS;
using Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.OperationResult;

namespace Admin.Manager.Role.Query.Get;

public class GetManagersByRoleHanlder:OperationResult,IQueryHandler<GetManagerByRoleQuery>

{

    private readonly IRoleRepository _roleRepository;


    public GetManagersByRoleHanlder(IRoleRepository roleRepository)
    {

        _roleRepository = roleRepository;
    }

    
    public async Task<JsonResult> Handle(GetManagerByRoleQuery request, CancellationToken cancellationToken)
    {

        var Result = _roleRepository.GetAdminById(request.Id, request.PageNumber, request.PageSize,request.Search);
        return Success(Result, "this is all admin");
        
    }
}