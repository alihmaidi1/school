using FluentValidation;
using Shared.File;

namespace Common.Feature.Image.Command.UploadBase64;

public class UploadBase64Validation : AbstractValidator<UploadBase64Command>
{

    public UploadBase64Validation()
    {

        RuleFor(x => x.Image)
            .NotEmpty()
            .NotNull()
            .Must(x=>x.IsBase64Image())
            .WithMessage("this field should be base64");

    }
    
    
}