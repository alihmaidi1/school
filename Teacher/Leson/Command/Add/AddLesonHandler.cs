using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Shared.Constant;
using Shared.CQRS;
using Shared.File;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Leson.Command.Add;

public class AddLesonHandler : OperationResult, ICommandHandler<AddLesonCommand>
{

    private readonly ApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;
    public AddLesonHandler(ApplicationDbContext context,ICurrentUserService currentUserService){


        _context=context;
        _currentUserService=currentUserService;


    }
    public async Task<JsonResult> Handle(AddLesonCommand request, CancellationToken cancellationToken)
    {

        var File=request.File.UploadFile(FolderName.Leson);
        
        var SubjectYear=_context.SubjectYears.FirstOrDefault(x=>x.TeacherSubject.TeacherId==_currentUserService.UserId&&x.TeacherSubject.SubjectId==request.SubjectId);
        if(SubjectYear is null) return ValidationError("SubjectId","This Subject Is Not Belongs To this teacher in this year");        
        
        var Leson=new Domain.Entities.ClassRoom.Leson(){

            Url=File,
            Name=request.Name,
            SubjectYearId=SubjectYear.Id

        };

        _context.Lesons.Add(Leson);
        await _context.SaveChangesAsync(cancellationToken);
        return Success("the leson was added successfully");  

    }
}
