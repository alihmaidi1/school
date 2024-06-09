using Common.CQRS;
using Domain.Dto.Teacher;
using Domain.Entities.Teacher.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Vacation;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.Teacher.Vacation.Query.GetAll;

public class GetVacationsHandler:OperationResult,IQueryHandler<GetVacationQuery>
{
    

    private ApplicationDbContext _context;

    public GetVacationsHandler(ApplicationDbContext context)
    {

        _context = context;
    }
    
    public async Task<JsonResult> Handle(GetVacationQuery request, CancellationToken cancellationToken)
    {
        var Vacations=_context
        .Vacations
        .Where(x=>x.Status==null)
        .Select(x=>new GetAllVacationDto{

            Id=x.Id,
            Type=x.VacationType.Name,
            Date=x.Date,
            Teacher=x.Teacher.Name,
            Reson=x.Reason
        })
        .ToPagedList(request.PageNumber,request.PageSize);
        return Success(Vacations,"this is all vacation ");
    }
}