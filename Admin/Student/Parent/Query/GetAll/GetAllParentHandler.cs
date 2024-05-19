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
        .Select(x=>new GetAllParentDto{

            Id=x.Id,
            Name=x.Name,
            Image=x.Image,
            Hash=x.Image,
            Children=x.Students.Count(),
            Email=x.Email,
            RequiredMoney=x.Students.Sum(y=>y.StudentBills.Sum(z=>z.Money-z.PaiedMoney)),
            PayedMoney=x.Students.Sum(y=>y.StudentBills.Sum(z=>z.PaiedMoney))


        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Parents);
    }
}