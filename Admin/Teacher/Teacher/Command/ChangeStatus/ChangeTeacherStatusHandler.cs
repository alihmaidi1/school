using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Command.ChangeStatus;

public class ChangeTeacherStatusHandler :OperationResult, ICommandHandler<ChangeTeacherStatusCommand>
{

    private ApplicationDbContext _context;

    public ChangeTeacherStatusHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(ChangeTeacherStatusCommand request, CancellationToken cancellationToken)
    {
        var teacher=new Domain.Entities.Teacher.Teacher.Teacher(){

                Id=request.Id,
                Status=request.Status,
                Reason=request.Status?null:request.Reason    
            

        };

        _context.Teachers.Update(teacher);
        await _context.SaveChangesAsync(cancellationToken);

        return Success("teacher status was updated successfully");
    }
}
