using Common.CQRS;
using Dto.Teacher.Warning;
using infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Teacher.Warning;
using Shared.Entity.EntityOperation;
using Shared.OperationResult;

namespace Admin.Teacher.Warning.Query.GetAll;

public class GetAllWarningHandler:OperationResult,
    IQueryHandler<GetAllWarningAdminQuery>
{

    private ApplicationDbContext _context;
    public GetAllWarningHandler(ApplicationDbContext context)
    {
        _context=context;
    
    }
    public async Task<JsonResult> Handle(GetAllWarningAdminQuery request, CancellationToken cancellationToken)
    {
            var Warnings= _context
            .Warnings
            .Where(x=>x.TeacherId==request.TeacherId)            
            .Include(x=>x.Admin)
            .Include(x=>x.Teacher)
            .Select(x=>new GetAllWarningAdminResponse()
            {
                 
                Id = x.Id,
                ManagerName = x.Admin.Name,
                Reason = x.Reason,
                Date = x.Date,
                Teacher = x.Teacher.Name
            })            
            .ToPagedList(request.PageNumber,request.PageSize);

        return Success(Warnings,"this is all warning");
    }
}