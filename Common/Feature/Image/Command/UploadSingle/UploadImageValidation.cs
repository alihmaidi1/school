using FluentValidation;
using Shared.Rule;

namespace Common.Feature.Image.Command.UploadSingle;

public class UploadImageValidation:AbstractValidator<UploadImageCommand>
{
    public UploadImageValidation() {

        RuleFor(x => x.Image)
            .NotEmpty()
            .NotNull()
            .Must(FileRule.IsFile)
            .WithMessage("this file should be image");
            

            
                
    }

    
}