using System.Data.Entity;
using Common.CQRS;
using Domain.Dto.Student;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.Student.Parent.Query.GetAll;

public class GetAllParentHandler:OperationResult,IQueryHandler<GetAllParentsQuery>
{

    private ApplicationDbContext _context;

    public GetAllParentHandler(ApplicationDbContext  context)
    {
        _context=context;

    }
    public async Task<JsonResult> Handle(GetAllParentsQuery request, CancellationToken cancellationToken)
    {
        var Parents=_context
        .Parents
        .AsNoTracking()
        .Select(x=>new GetAllParentDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Image,
            Children=x.Students.Count(),
            Email=x.Email,
            RequiredMoney=x.Students.SelectMany(x=>x.StudentBills).Sum(y=>y.Money-y.PaiedMoney),
            PayedMoney=x.Students.SelectMany(x=>x.StudentBills).Sum(y=>y.PaiedMoney),
            Students=x.Students.Select(y=>new GetAllParentDto.Student{

                Id=y.Id,
                Name=y.Name,
                level=y.Level,
                gender=y.Gender,
                Email=y.Email,
                Image=y.Image,
                Hash=y.Hash

            }).ToList()




        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Parents);
    }
}