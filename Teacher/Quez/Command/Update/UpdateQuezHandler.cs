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

namespace Teacher.Quez.Command.Update;

public class UpdateQuezHandler : OperationResult,ICommandHandler<UpdateQuezCommand>
{
    private readonly ApplicationDbContext _context;
    public UpdateQuezHandler(ApplicationDbContext context){


            _context=context;


    }
    public  async Task<JsonResult> Handle(UpdateQuezCommand request, CancellationToken cancellationToken)
    {


        await _context
        .Quezs
        .Where(x=>x.Id==request.Id)
        .ExecuteUpdateAsync(setter=>
            setter.SetProperty(x=>x.Name,request.Name)
                  .SetProperty(x=>x.StartAt,request.StartAt)
                  .SetProperty(x=>x.EndAt,request.EndAt),
        cancellationToken);

        return Success("updated successfully");
    }
}
