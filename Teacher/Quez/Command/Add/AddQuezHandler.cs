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
using Shared.Services.User;

namespace Teacher.Quez.Command.Add;

public class AddQuezHandler : OperationResult, ICommandHandler<AddQuezCommand>
{


    private readonly ApplicationDbContext _context;
    private ICurrentUserService _currentUserService;
    public AddQuezHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _currentUserService=currentUserService;
        _context=context;

    }
    public async Task<JsonResult> Handle(AddQuezCommand request, CancellationToken cancellationToken)
    {

        var SubjectYearId=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.TeacherSubject.SubjectId==request.SubjectId)
        .Where(x=>x.TeacherSubject.TeacherId==_currentUserService.GetUserid())
        .Where(x=>x.ClassYear.Status)     
        .Select(x=>x.Id)   
        .First();
        var Quez=new Domain.Entities.Quez.Quez(){

            Name=request.Name,
            StartAt=request.StartAt,
            SubjectYearId=SubjectYearId
            
        };
        var StudentSubjects=_context.SubjectYears.Where(x=>x.ClassYear.Status&&x.TeacherSubject.TeacherId==_currentUserService.GetUserid())
        .SelectMany(x=>x.StudentSubjects)        
        .ToList();
        
        Quez.StudentQuezs=StudentSubjects.Select(x=>new StudentQuez(){
            StudentId=x.StudentId,
        }).ToList();        
        _context.Quezs.AddRange(Quez);
        _context.SaveChanges();
        return Success("quez was added successfully");
    }
}
