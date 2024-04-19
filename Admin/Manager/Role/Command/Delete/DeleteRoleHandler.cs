using Common.CQRS;
using Domain.Entities.Role;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleHandler:OperationResult,ICommandHandler<DeleteRoleCommand>

{
    
    private readonly IRoleRepository _roleRepository;


    public DeleteRoleHandler(IRoleRepository roleRepository)
    {

        _roleRepository = roleRepository;

    }
    
    public async Task<JsonResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {

        await _roleRepository.DeleteAsync(new Domain.Entities.Role.Role()
        {
            Id = request.Id
        });
        return Success("this role was deleted successfully");
    }
}