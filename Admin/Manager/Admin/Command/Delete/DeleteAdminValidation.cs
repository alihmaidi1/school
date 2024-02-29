using Domain.Entities.Manager.Admin;
using FluentValidation;
using Repository.Manager.Admin;

namespace Admin.Manager.Admin.Command.Delete;

public class DeleteAdminValidation:AbstractValidator<DeleteAdminCommand>
{
 
    public DeleteAdminValidation(IAdminRepository adminRepository)
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("id should be not empty")
            .NotNull()
            .WithMessage("id should be not null")
            .Must(x => adminRepository.IsExists(new AdminID(x)))
            .WithMessage("this admin is not exists in our data");
    }
}