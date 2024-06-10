using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Parent.Notification.Command.Delete;

public class DeleteNotificationHandler : OperationResult,ICommandHandler<DeleteNotificationCommand>
{

    private ApplicationDbContext _context;
    public DeleteNotificationHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(DeleteNotificationCommand request, CancellationToken cancellationToken)
    {


        await _context
        .AccountNotifications
        .Where(x=>x.Id==request.Id)
        .ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        
        return Deleted();
    }
}
