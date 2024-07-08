using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using Hangfire.Storage.Monitoring;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.OperationResult;
using Shared.Services.User;

namespace Student.Subject.Query.GetAllResult;

public class GetAllResultHandler : OperationResult,IQueryHandler<GetAllResultQuery>
{

    private ApplicationDbContext _context;
    private Guid? Id;
    public GetAllResultHandler(ApplicationDbContext context,ICurrentUserService currentUserService){

        _context=context;
        Id=currentUserService.GetUserid();

    }
    
    public async Task<JsonResult> Handle(GetAllResultQuery request, CancellationToken cancellationToken)
    {

        var Result=_context
        .StudentSubjects
        .AsNoTracking()
        .Where(x=>x.StudentId==Id)
        .Where(x=>x.SubjectYear.ClassYear.Status)
        .Where(x=>x.Mark.HasValue)
        .Select(x=>new GetAllResultDto{

            Id=x.SubjectYear.Subject.Id,
            Name=x.SubjectYear.Subject.Name,
            Mark=x.Mark!.Value
        })
        .ToList();

        return Success(Result);
    }
}
