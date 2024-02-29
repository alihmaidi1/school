using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Microsoft.AspNetCore.Mvc;
using Repository.Manager.Admin;
using Shared.OperationResult;

namespace Admin.Manager.Admin.Command.Delete;

public class DeleteAdminHandler:OperationResult,
    ICommandHandler<DeleteAdminCommand>
{

    private readonly IAdminRepository AdminRepository;

    public DeleteAdminHandler(IAdminRepository AdminRepository)
    {

        this.AdminRepository = AdminRepository;

    }
    
    
    public async Task<JsonResult> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        AdminRepository.Delete(new AdminID(request.Id));
        return Success("this admin was deleted successfully");
    }
}