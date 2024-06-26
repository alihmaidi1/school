using Domain.Entities.Manager.Admin;
using Domain.Entities.Role;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;
using Repository.Manager.Admin;
using Repository.Manager.Role;

namespace Admin.Manager.Admin.Command.Update;

public class UpdateAdminValidation:AbstractValidator<UpdateAdminCommand>
{

    public UpdateAdminValidation(ApplicationDbContext context,IRoleRepository roleRepository,IAdminRepository adminRepository)
    {

        RuleFor(x => x.Status)
            .NotNull();


        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
        //
        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null")
            .Must(Id => roleRepository.IsExists(Id).GetAwaiter().GetResult())
            .WithMessage("this role is not valid");
        
        RuleFor(x => x.Email)
        .EmailAddress()
        .Must((request,email)=>!context.Admins.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).Any(x=>x.Email==email&&x.Id!=request.AdminId)&&!context.Teachers.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).Any(x=>x.Email==email))
        .WithMessage("this email is already exists in our data");
       
       
        RuleFor(x => x.Password)
            .NotEmpty()
            .NotNull()
            .MinimumLength(8);



        RuleFor(x => x.AdminId)
            .NotEmpty()
            .NotNull()
            .Must(id => context.Admins.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).Any(x=>x.Id==id))
            .WithMessage("this admin is not exists in our data");

        RuleFor(x=>x.Image)
            .Must(id=>context.Images.Any(x=>x.Id==id))
            .When(x=>x.Image!=null)
            .WithMessage("image is not exists");
        
    }
}