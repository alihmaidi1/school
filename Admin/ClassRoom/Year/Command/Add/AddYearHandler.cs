using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Year.Command.Add;
public class AddYearHandler : OperationResult,ICommandHandler<AddYearCommand>
{

    private ApplicationDbContext _context;
    public AddYearHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(AddYearCommand request, CancellationToken cancellationToken)
    {

        var Year=new Domain.Entities.ClassRoom.Year{


            Date=request.Datetime
        };


        _context.Years.Add(Year);
        _context.SaveChanges();

        return Success();
    }
}
