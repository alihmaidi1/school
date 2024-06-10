using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Banner.Command.Delete;

public class DeleteBannerHandler : OperationResult,ICommandHandler<DeleteBannerCommand>
{

    private ApplicationDbContext _context;
    public DeleteBannerHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
    {

        await _context
        .Banners
        .Where(x=>x.Id==request.Id)
        .ExecuteDeleteAsync(cancellationToken);
        return Deleted();
    }
}
