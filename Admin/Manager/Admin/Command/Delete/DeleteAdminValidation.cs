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
            .NotNull()
            .Must(x => adminRepository.IsExists(x).GetAwaiter().GetResult())
            .WithMessage("this admin is not exists in our data");
    }
}