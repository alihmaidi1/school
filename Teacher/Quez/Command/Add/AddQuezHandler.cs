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

        var StudentQuezs=_context
        .StudentSubjects
        .Include(x=>x.SubjectYear)
        .Where(x=>x.SubjectYear.SubjectId==request.SubjectId)
        .Select(x=>new StudentQuez(){


            Name=request.Name,
            StartAt=request.StartAt,
            StudentSubjectId=x.Id

        })
        .ToList();
        
        var Quez=new StudentQuez(){


        };


        return Success("quez was added successfully");
    }
}
