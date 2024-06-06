using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.Student.Student.Query.GetAllInstallment;

public class GetAllInstallmentHandler : OperationResult ,IQueryHandler<GetAllInstallmentQuery>
{

    private ApplicationDbContext _context;
    public GetAllInstallmentHandler(ApplicationDbContext context){


        _context=context;
    }
    public async Task<JsonResult> Handle(GetAllInstallmentQuery request, CancellationToken cancellationToken)
    {

        var Installments=_context
        .ClassYears
        .AsNoTracking()
        .AsSplitQuery()
        .Where(x=>!x.Status)
        .Where(x=>x.SubjectYears.Any(x=>x.StudentSubjects.Any(x=>x.StudentId==request.Id)))

        .Select(x=>new GetAllInstallmentDto{

            Id=x.ClassId,
            Name=x.Class.Name,
            Year=x.Year.Date,
            Mark=(
                x.SubjectYears.SelectMany(x=>x.StudentSubjects.Where(x=>x.StudentId==request.Id)).Sum(x=>x.Mark.Value)/
                x.SubjectYears.SelectMany(x=>x.StudentSubjects.Where(x=>x.StudentId==request.Id)).Count()
                
                )
            

            
        })
        .ToPagedList(request.PageNumber,request.PageSize);

        return Success(Installments,"this is all installment");

    }
}
