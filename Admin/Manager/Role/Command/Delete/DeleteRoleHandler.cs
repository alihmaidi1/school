using Common.CQRS;
using Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.OperationResult;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleHandler:OperationResult,
    ICommandHandler<DeleteRoleCommand>

{
    
    private readonly IRoleRepository roleRepository;


    public DeleteRoleHandler(IRoleRepository roleRepository)
    {

        this.roleRepository = roleRepository;

    }
    
    public async Task<JsonResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {

        await roleRepository.DeleteAsync(new Domain.Entities.Role.Role()
        {
            Id = new RoleID(request.Id)
        });
        // roleRepository.Delete(request.Id);
        return Success("this role was deleted successfully");

    }
}