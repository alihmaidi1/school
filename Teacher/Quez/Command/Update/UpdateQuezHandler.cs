using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Quez;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Teacher.Quez.Command.Update;

public class UpdateQuezHandler : OperationResult,ICommandHandler<UpdateQuezCommand>
{
    private readonly ApplicationDbContext _context;
    public UpdateQuezHandler(ApplicationDbContext context){


            _context=context;


    }
    public  async Task<JsonResult> Handle(UpdateQuezCommand request, CancellationToken cancellationToken)
    {

        var Quez=new Domain.Entities.Quez.Quez(){

            Id=request.Id,
            Name=request.Name,
            StartAt=request.StartAt
        };

        _context.Quezs.Update(Quez);
        await _context.SaveChangesAsync(cancellationToken);
        return Success("updated successfully");
    }
}
