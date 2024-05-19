using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Quez.Command.Add;

public class AddQuezHandler : OperationResult, ICommandHandler<AddQuezCommand>
{


    private readonly ApplicationDbContext _context;
    public AddQuezHandler(ApplicationDbContext context){


        _context=context;

    }
    public async Task<JsonResult> Handle(AddQuezCommand request, CancellationToken cancellationToken)
    {

        var Quez=new Domain.Entities.Quez.Quez(){

            Name=request.Name,
            StartAt=request.StartAt
        };
        var StudentSubjects=_context.SubjectYears.Where(x=>x.SubjectId==request.SubjectId&&x.Year.Date==DateTime.Now.Date)
        .SelectMany(x=>x.StudentSubjects)
        .ToList();

        Quez.StudentQuezs=StudentSubjects.Select(x=>new StudentQuez(){

            StudentSubjectId=x.Id,
            QuezId=Quez.Id
        }).ToList();
        _context.Quezs.AddRange(Quez);
        _context.SaveChanges();

        return Success("quez was added successfully");
    }
}
