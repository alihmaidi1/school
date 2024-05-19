using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.ClassRoom.Subject;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.ClassRoom.Subject.Query.GetAllByYear;

public class GetAllSubjectByYearHandler : OperationResult, IQueryHandler<GetAllSubjectByYearQuery>
{

    private ApplicationDbContext _context;
    public GetAllSubjectByYearHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllSubjectByYearQuery request, CancellationToken cancellationToken)
    {

        var SubjectResponse=new GetAllSubjectByYearDto(){


        };
        var Subjects=_context
        .SubjectYears      
        .Where(x=>x.YearId==request.YearId)
        .Select(x=>x.Subject)          
        .Select(x=>new GetAllSubjectByYearDto.Subject{
            Id=x.Id,
            Name=x.Name,
            Year=x.Class.Name,
            Degree=x.Degree,
            MinDegree=x.MinDegree,
        }).ToPagedList(request.PageNumber,request.PageSize);
        SubjectResponse.Subjects=Subjects;
        SubjectResponse.TotalTeacher=_context.Teachers.Where(x=>x.Status).Count();
        return Success(SubjectResponse,"this is all subject");
    }
}
