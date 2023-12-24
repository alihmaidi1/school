using Common.Feature.Image.Command.Model;
using FluentValidation;
using Shared.Rule;

namespace Common.Feature.Image.Command.Validation;

public class UploadImagesValidation:AbstractValidator<UploadImagesCommand>
{
 
    
    public UploadImagesValidation() {


        RuleForEach(x=>x.images)
            .NotNull()
            .WithMessage("image can not be null")
            .NotEmpty()
            .WithMessage("image can not be empty")
            .Must(FileRule.IsFile)
            .WithMessage("image extension should be png,jpg,jpeg");



    }

}