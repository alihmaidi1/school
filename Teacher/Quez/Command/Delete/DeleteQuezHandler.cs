using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Quez.Command.Delete;

public class DeleteQuezHandler : OperationResult,ICommandHandler<DeleteQuezCommand>
{

    private readonly ApplicationDbContext _context;
    public DeleteQuezHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(DeleteQuezCommand request, CancellationToken cancellationToken)
    {

        await _context.Quezs.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTime.Now));
        await _context.StudentQuezs.Where(x=>x.QuezId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);        
        await _context.Questions.Where(x=>x.QuezId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        await _context.Answers.Where(x=>x.Question.QuezId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);
        await _context.StudentAnswers.Where(x=>x.Answer.Question.QuezId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow),cancellationToken);        
        return Success("quez deleted successfully");

    }
}
