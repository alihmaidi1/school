using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Banner.Command.Delete;

public class DeleteBannerValidation: AbstractValidator<DeleteBannerCommand>
{

    public DeleteBannerValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Banners.Any(x=>x.Id==id))
        .WithMessage("this banner is not exists in our data");

    }

}
