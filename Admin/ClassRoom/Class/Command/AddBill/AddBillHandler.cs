using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ClassRoom;
using Domain.Entities.Student.StudentBill;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.ClassRoom.Class.Command.AddBill;

public class AddBillHandler : OperationResult,ICommandHandler<AddBillCommand>
{
    private ApplicationDbContext _context;
    public AddBillHandler(ApplicationDbContext context){

        _context=context;
    }
    public async Task<JsonResult> Handle(AddBillCommand request, CancellationToken cancellationToken)
    {

        var students=_context
        .ClassYears
        .Where(x=>x.ClassId==request.Id&&x.Status)
        .SelectMany(x=>x.SubjectYears)
        .SelectMany(x=>x.StudentSubjects.Select(x=>x.Student))
        .Distinct()
        .ToList();


        var ClassYearId=_context
        .ClassYears
        .Where(x=>x.ClassId==request.Id&&x.Status)
        .Select(x=>x.Id)
        .First();

        var bill=new Bill{

            Money=request.Money,
            Date=request.Date,
            ClassYearId=ClassYearId,
            StudentBills=students.Select(x=>new StudentBill{
                StudentId=x.Id,
                Money=request.Money

            }).ToList()

        };

        _context.Bills.Add(bill);
        await _context.SaveChangesAsync(cancellationToken);
        return Created("bill was added successfully");
        
    }
}
