using Common.CQRS;
using Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Manager.Role.Command.Update;

public class UpdateRoleHandler:OperationResult,ICommandHandler<UpdateRoleCommand>

{
    
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleHandler(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }

    public async Task<JsonResult> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    { 
       await _roleRepository.UpdateAsync(new Domain.Entities.Role.Role()
        {
            Id = request.Id,
            Name = request.Name,
            Permissions = request.Permissions
            
        });
       
        return Success("role was updated successfully");

    }
}