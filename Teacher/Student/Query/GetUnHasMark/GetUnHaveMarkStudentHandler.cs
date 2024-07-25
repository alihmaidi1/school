using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Org.BouncyCastle.Pqc.Crypto.Sike;
using Shared.OperationResult;
using Shared.Services.User;

namespace Teacher.Student.Query.GetUnHasMark;

public class GetUnHaveMarkStudentHandler : OperationResult,IQueryHandler<GetUnhaveMarkStudentQuery>
{

    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public GetUnHaveMarkStudentHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        _currentUserService=currentUserService;

    }
    
    public async Task<JsonResult> Handle(GetUnhaveMarkStudentQuery request, CancellationToken cancellationToken)
    {

        var StudentName=_context
        .SubjectYears
        .AsNoTracking()
        .Where(x=>x.TeacherId==_currentUserService.GetUserid())
        .Where(x=>x.SubjectId==request.SubjectId)
        .SelectMany(x=>x.StudentSubjects.Where(x=>x.Mark==null))
        .Select(x=>new GetStudentNameDto{


            Id=x.Student.Id,
            Name=x.Student.Name

        })
        .ToList();

        return Success(StudentName);


    }
}
