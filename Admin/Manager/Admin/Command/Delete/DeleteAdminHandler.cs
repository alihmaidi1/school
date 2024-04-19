using Common.CQRS;
using Domain.Entities.Manager.Admin;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Repository.Manager.Admin;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Manager.Admin.Command.Delete;

public class DeleteAdminHandler:OperationResult,
    ICommandHandler<DeleteAdminCommand>
{

    private readonly IAdminRepository AdminRepository;
    private readonly ApplicationDbContext _dbContext;

    public DeleteAdminHandler(ApplicationDbContext dbContext,IAdminRepository AdminRepository)
    {

        this.AdminRepository = AdminRepository;
        _dbContext=dbContext;

    }
    
    
    public async Task<JsonResult> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
    {
        await _dbContext.Admins.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Success("this admin was deleted successfully");

    }
}