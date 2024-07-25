using System.Security.Claims;
using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Warning;
using Shared.CQRS;
using Shared.OperationResult;
using Shared.Services.User;

namespace Admin.Teacher.Warning.Command.Add;

public class AddWarningHandler:OperationResult,
    ICommandHandler<AddWarningCommand>
{
    private ApplicationDbContext _context;

    private ICurrentUserService _currentUserService;
    public AddWarningHandler(ApplicationDbContext context,ICurrentUserService currentUserService)
    {

        _currentUserService=currentUserService;
        _context=context;

    }
    
    public async Task<JsonResult> Handle(AddWarningCommand request, CancellationToken cancellationToken)
    {
        var Warning = new Domain.Entities.Teacher.Warning.Warning()
        {
            AdminId = _currentUserService.GetUserid()!.Value,
            TeacherId = request.TeacherID,
            Reason = request.Reson,
            Date = DateTime.Now.Year
        };
        _context.Warnings.Add(Warning);
        _context.SaveChanges();
        
        
        return Success("Warning Was added successfully");

    }
}