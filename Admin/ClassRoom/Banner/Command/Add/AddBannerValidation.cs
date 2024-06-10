using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Banner.Command.Add;

public class AddBannerValidation: AbstractValidator<AddBannerCommand>
{

    public AddBannerValidation(ApplicationDbContext context){

        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull()
        .Must(name=>!context.Banners.Any(x=>x.Name==name))
        .WithMessage("this banner name is already exists");

        RuleFor(x=>x.StartAt)
        .NotEmpty()
        .NotNull()
        .GreaterThan(DateTimeOffset.UtcNow);

        RuleFor(x=>x.EndAt)
        .NotEmpty()
        .NotNull()
        .GreaterThan(x=>x.StartAt);

        RuleFor(x=>x.Url)
        .NotEmpty()
        .NotNull();

        RuleFor(x=>x.Image)
        .NotEmpty()
        .NotNull()
        .Must(image=>context.Images.Any(x=>x.Id==image))
        .WithMessage("this image is not exists in our data");

    }

}
