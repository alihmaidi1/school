using Common.Feature.Image.Command.Model;
using FluentValidation;
using Shared.File;

namespace Common.Feature.Image.Command.Validation;

public class UploadBase64ImageValidation:AbstractValidator<UploadBase64ImageCommand>
{
    
    public UploadBase64ImageValidation() {


        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("image can not be empty")
            .NotNull()
            .WithMessage("image can not be null")
            .Must(x => x.IsBase64Image())
            .WithMessage("image should be base64");
        
    }
    
}