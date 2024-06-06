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

        await _context.StudentBills.Where(x=>x.StudentId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        await _context.StudentSubjects.Where(x=>x.StudentId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        await _context.StudentAnswers.Where(x=>x.StudentQuez.StudentId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        await _context.StudentQuezs.Where(x=>x.StudentId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);        
        // await _context.Where(x=>x.StudentId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        await _context.Students.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        
        return Success("student deleted successfully");
    }
}
