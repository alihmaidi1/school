using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Command.Delete;

public class DeleteTeacherHandler : OperationResult, ICommandHandler<DeleteTeacherCommand>
{


    public ApplicationDbContext _context;

    public DeleteTeacherHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {

        _context.Teachers.Where(x=>x.Id==request.Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow));        
        _context.Vacations.Where(x=>x.TeacherId==request.Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow));
        _context.Warnings.Where(x=>x.TeacherId==request.Id).ExecuteUpdate(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow));
        return Deleted();
    }
}
