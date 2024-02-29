using Common.CQRS;
using Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.OperationResult;

namespace Admin.Manager.Role.Command.Update;

public class UpdateRoleHandler:OperationResult,
    ICommandHandler<UpdateRoleCommand>

{
    
    private readonly IRoleRepository roleRepository;

    public UpdateRoleHandler(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public async Task<JsonResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    { 
       await roleRepository.UpdateAsync(new Domain.Entities.Role.Role()
        {
            Id = new RoleID(request.Id),
            Name = request.Name,
            Permissions = request.Permissions
            
        });
        return Success("role was updated successfully");
    }
}