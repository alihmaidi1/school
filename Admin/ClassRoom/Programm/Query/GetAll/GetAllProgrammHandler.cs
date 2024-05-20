using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;

namespace Admin.ClassRoom.Programm.Query.GetAll;

public class GetAllProgrammHandler : OperationResult ,IQueryHandler<GetAllProgrammQuery>
{

    private ApplicationDbContext _context;
    public GetAllProgrammHandler(ApplicationDbContext context){


        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllProgrammQuery request, CancellationToken cancellationToken)
    {

        // var Programms=_context
        // .Stages
        // .Select(x=>new GetAllProgrammDto{

        //     Id=x.Id,
        //     Name=x.Name,
        //     Classes=x.Classes.Select(y=>new GetAllProgrammDto.Class{

        //         Id=y.Id,
        //         Name=y.Name,
        //         Programm=y
        //         .Subjects
        //         .SelectMany(z=>z.SubjectYears)
        //         .Where(z=>z.Year.Date.Year==DateTime.Now.Year)
        //         .SelectMany(z=>z.Programs)
        //         .GroupBy(z=>z.Day)
        //         .Select(z=>new GetAllProgrammDto.Programm{

        //             Day=z.Key,
        //             ProgrammInfos=z.Select(a=>new GetAllProgrammDto.ProgrammInfo{

        //                 SubjectId=a.SubjectYear.SubjectId,
        //                 StartAt=a.StartAt,
        //                 EndAt=a.EndAt

        //             }).ToList()


        //         }).ToList()
                
                

        //     }).ToList()




        // })
        // .ToList();
        // return Success(Programms,"this is all programm");
        return null;
    }
}
