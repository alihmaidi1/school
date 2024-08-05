using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Student.Quez.Command.SolveQuez;
public class SolveQuezHandler : OperationResult,ICommandHandler<SolveQuezCommand>
{

    private ApplicationDbContext _context;
    public  SolveQuezHandler(ApplicationDbContext context){

        _context=context;

    }
    public async Task<JsonResult> Handle(SolveQuezCommand request, CancellationToken cancellationToken)
    {


        var StudentAnswer=request.Answers.Select(x=>new StudentAnswer{


            StudentQuizId=request.Id,
            AnswerId=x

        })
        .ToList();


        _context.StudentAnswers.AddRange(StudentAnswer);
        await _context.SaveChangesAsync(cancellationToken);

        var Mark=_context
        .StudentQuezs
        .AsNoTracking()
        .Where(x=>x.Id==request.Id)
        .SelectMany(x=>x.StudentAnswers.Where(x=>x.Answer.IsCorrect))
        .Sum(x=>x.Answer.Question.Score)/_context
        .StudentQuezs
        .AsNoTracking()
        .Where(x=>x.Id==request.Id)
        .SelectMany(x=>x.Quez.Questions)
        .Sum(x=>x.Score);
        return Success(Mark,"quez solved successfully");
    }
}
