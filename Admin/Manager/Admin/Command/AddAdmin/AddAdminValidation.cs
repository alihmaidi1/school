using Admin.Admin.Command.AddAdmin;
using Domain.Entities.Role;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Repository.Manager.Admin;
using Repository.Manager.Role;
using Shared.Rule;

namespace Admin.Manager.Admin.Command.AddAdmin;

public class AddAdminValidation:AbstractValidator<AddAdminCommand>
{

    public AddAdminValidation(IAdminRepository adminRepository,IRoleRepository roleRepository,IWebHostEnvironment webHostEnvironment)
    {
        
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null");


        RuleFor(x => x.RoleId)
            .NotEmpty()
            .WithMessage("name should be not empty")
            .NotNull()
            .WithMessage("name should be not null")
            .Must(Id => roleRepository.IsExists(new RoleID(Id)))
            .WithMessage("this role is not valid");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("password should be not empty")
            .NotNull()
            .WithMessage("password should be not null")
            .MinimumLength(8)
            .WithMessage("password should be at leat 8 charecter");


        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("email should be not empty")
            .NotNull()
            .WithMessage("email should be not null")
            .EmailAddress()
            .Must(x => !adminRepository.IsEmailExists(x))
            .WithMessage("email address is already exists");


        RuleFor(x => x.Image)
            .Must(image => FileRule.IsFileExists(image,webHostEnvironment.WebRootPath))
            .WithMessage("this image is not exists in our data");

    }
    
}