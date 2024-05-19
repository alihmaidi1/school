using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X9;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.Teacher.Command.Delete;

public class DeleteTeacherHandler : OperationResult, ICommandHandler<DeleteTeacherCommand>
{


    ApplicationDbContext _context;

    public DeleteTeacherHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {

        await _context.Teachers.Where(x=>x.Id==request.Id).ExecuteDeleteAsync();
        await _context.SaveChangesAsync(cancellationToken);
        return Deleted();
    }
}
