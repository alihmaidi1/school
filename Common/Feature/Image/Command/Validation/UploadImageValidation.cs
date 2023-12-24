using Common.Feature.Image.Command.Model;
using FluentValidation;
using Shared.Rule;

namespace Common.Feature.Image.Command.Validation;

public class UploadImageValidation:AbstractValidator<UploadImageCommand>
{
    public UploadImageValidation() {

        RuleFor(x => x.Image)
            .NotEmpty()
            .WithMessage("image can not be empty")
            .NotNull()
            .WithMessage("image can not be null")
            .Must(FileRule.IsFile)
            .WithMessage("this file should be image");
            

            
                
    }

    
}