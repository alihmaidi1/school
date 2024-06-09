using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Manager.Role;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Manager.Role.Command.Delete;

public class DeleteRoleHandler:OperationResult,ICommandHandler<DeleteRoleCommand>

{
    
    private readonly IRoleRepository _roleRepository;

    private ApplicationDbContext _context;

    public DeleteRoleHandler(IRoleRepository roleRepository,ApplicationDbContext context)
    {
        _context=context;
        _roleRepository = roleRepository;

    }
    
    public async Task<JsonResult> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await _context
        .Roles
        .Where(x=>x.Id==request.Id)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        return Success("this role was deleted successfully");
    }
}