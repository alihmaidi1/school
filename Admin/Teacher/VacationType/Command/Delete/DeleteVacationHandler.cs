using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.VacationType.Command.Delete;

public class DeleteVacationHandler :OperationResult ,ICommandHandler<DeleteVacationTypeCommand>
{


    private ApplicationDbContext _context;
    public DeleteVacationHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(DeleteVacationTypeCommand request, CancellationToken cancellationToken)
    {
        await _context.VacationTypes.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);    
        return Deleted();
            
    }
}
