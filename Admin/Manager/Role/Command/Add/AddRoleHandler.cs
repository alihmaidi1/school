using Common.CQRS;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Role;
using Shared.OperationResult;

namespace Admin.Manager.Role.Command.Add;

public class AddRoleHandler:OperationResult,
    ICommandHandler<AddRoleCommand>
{
    
    private readonly IRoleRepository roleRepository;

    
    public AddRoleHandler(IRoleRepository roleRepository)
    {
        this.roleRepository = roleRepository;
    }

    public async Task<JsonResult> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        roleRepository.AddAsync(new Domain.Entities.Role.Role()
        {

            Name = request.Name,
            Permissions = request.Permissions

        });
        return Success("role was added successfully");
    }
}