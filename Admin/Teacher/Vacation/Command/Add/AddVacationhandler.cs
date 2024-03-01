using System.Security.Claims;
using Common.CQRS;
using Domain.Entities.Manager.Admin;
using Domain.Entities.Teacher.Teacher;
using Domain.Enum;
using infrutructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Manager.Admin;
using Repository.Teacher.Vacation;
using Shared.OperationResult;

namespace Admin.Teacher.Vacation.Command.Add;

public class AddVacationhandler:OperationResult,
    ICommandHandler<AddVacationCommand>
{
    private IVacationRepository VacationRepository;

    private IAdminRepository AdminRepository;
    private IHttpContextAccessor httpContextAccessor;
    public AddVacationhandler(IAdminRepository AdminRepository,IVacationRepository VacationRepository,IHttpContextAccessor httpContextAccessor)
    {

        this.AdminRepository = AdminRepository;
        this.httpContextAccessor = httpContextAccessor;
        this.VacationRepository = VacationRepository;

    }
    public async Task<JsonResult> Handle(AddVacationCommand request, CancellationToken cancellationToken)
    {
        
        var TeacherID = httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x=>x.Type==ClaimTypes.NameIdentifier).Value;
        var Vacation = new Domain.Entities.Teacher.Vacation.Vacation()
        {

            TeacherId = new TeacherID(new Guid(TeacherID)),
            Reason = request.Reason,
            Days = request.Days,
            
        };
        await VacationRepository.AddAsync(Vacation);
        List<AdminID> adminIds = AdminRepository.GetIds(PermissionEnum.Vacation.ToString());
        // send notification to all admins
        return Success("the vacation was send to admin successfully");
    }
}