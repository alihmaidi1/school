using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;

namespace Admin.ClassRoom.Class.Command.FinishYear;

public class FinishYearHandler : ICommandHandler<FinishYearCommand>
{

    private ApplicationDbContext _context;
    public FinishYearHandler(ApplicationDbContext context){

        _context=context;

    }
    public Task<JsonResult> Handle(FinishYearCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
