using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Question.Command.Delete;

public class DeleteQuestionHandler : OperationResult, ICommandHandler<DeleteQuestionCommand>
{

    private ApplicationDbContext _context;
    public DeleteQuestionHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(DeleteQuestionCommand request, CancellationToken cancellationToken)
    {

        await _context.Questions.Where(x=>x.Id==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow));        
        await _context.Answers.Where(x=>x.QuestionId==request.Id).ExecuteUpdateAsync(setter=>setter.SetProperty(x=>x.DateDeleted,DateTimeOffset.UtcNow));                
        return Deleted();
    }
}
