using System.Security.Claims;
using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Teacher.Warning;
using Shared.CQRS;
using Shared.OperationResult;

namespace Admin.Teacher.Warning.Command.Add;

public class AddWarningHandler:OperationResult,
    ICommandHandler<AddWarningCommand>
{
    
    private IWarningRepository WarningRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AddWarningHandler(IWarningRepository WarningRepository,IHttpContextAccessor _httpContextAccessor)
    {

        this.WarningRepository = WarningRepository;
        this._httpContextAccessor = _httpContextAccessor;

    }
    
    public async Task<JsonResult> Handle(AddWarningCommand request, CancellationToken cancellationToken)
    {
        // var AdminId = _httpContextAccessor.HttpContext.User.Claims.First(x=>x.Type==ClaimTypes.NameIdentifier).Value;
        // var Warning = new Domain.Entities.Teacher.Warning.Warning()
        // {
        //     AdminId = new AdminID(new Guid(AdminId)),
        //     TeacherId = new TeacherID(request.TeacherID),
        //     Reason = request.Reson,
        //     Date = DateTime.Now.Year
        // };
        //
        // await WarningRepository.AddAsync(Warning);
        // return Success("Warning Was added successfully");

        return null;
    }
}