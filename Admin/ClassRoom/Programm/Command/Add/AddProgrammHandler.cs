using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Math.EC.Rfc7748;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Programm.Command.Add;
public class AddProgrammHandler : OperationResult, ICommandHandler<AddProgrammCommand>
{


    private ApplicationDbContext _context;


    public AddProgrammHandler(ApplicationDbContext context){


        _context=context;

    }
    public async Task<JsonResult> Handle(AddProgrammCommand request, CancellationToken cancellationToken)
    {

        // var SubjectIds=request
        // .Programms
        // .SelectMany(x=>x.ProgrammInfos)
        // .Select(x=>x.SubjectId)
        // .Distinct()
        // .ToList();

        // var SubjectYearIds= _context
        // .SubjectYears
        // .Where(x=>SubjectIds.Contains(x.Id)&&x.Year.Date.Date.Year==DateTime.Now.Year)
        // .Select(x=>new {

        //     Id=x.Id,
        //     SubjectId=x.SubjectId
        // })                
        // .ToList();

        // List<Program> programs=request.Programms.SelectMany(x=>x.ProgrammInfos.Select(y=>new Program{
        //     StartAt=y.StartAt,
        //     EndAt=y.EndAt,
        //     Day=x.Day,
        //     SubjectYearId=SubjectYearIds.First(x=>x.SubjectId==y.SubjectId).Id
        // })).ToList();
        // _context.Programs.AddRange(programs);
        // _context.SaveChanges();

        // return Success("Programm was added successfully");
        return null;        
    }
}
