using Common.CQRS;
using Domain.Enum;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.Manager.Role.Query.GetPermissions;

public class GetPermissionsHandler:OperationResult,
    IQueryHandler<GetPermissionsQuery>
{
    
    
    public async Task<JsonResult> Handle(GetPermissionsQuery request, CancellationToken cancellationToken)
    {
        var Permissions = Enum.GetNames(typeof(PermissionEnum)).ToList();

        return Success(Permissions, "this is all permissions");
    }
}