
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Teacher.Warning;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.VacationType.Command.Add;

public class AddVacationTypeHandler :OperationResult, ICommandHandler<AddVacationTypeCommand>
{

    private ApplicationDbContext _context;
    public AddVacationTypeHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(AddVacationTypeCommand request, CancellationToken cancellationToken)
    {

        var VacationType=new Domain.Entities.Teacher.Warning.VacationType(){

            Name=request.Name

        } ;

        await _context.VacationTypes.AddAsync(VacationType);
        await _context.SaveChangesAsync();
        return Created("data was created successfully");
    }
}
