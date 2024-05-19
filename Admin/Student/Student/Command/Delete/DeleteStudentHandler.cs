using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Student.Student.Command.Delete;

public class DeleteStudentHandler :OperationResult , ICommandHandler<DeleteStudentCommand>
{

    private ApplicationDbContext _context;
    public DeleteStudentHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
    {

        await _context.Students.Where(x=>x.Id==request.Id).ExecuteDeleteAsync(cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Success("student deleted successfully");
    }
}
