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
        return Success("quez solved successfully");
    }
}
