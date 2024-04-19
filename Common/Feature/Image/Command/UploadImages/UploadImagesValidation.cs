using FluentValidation;
using Shared.Rule;

namespace Common.Feature.Image.Command.UploadImages;

public class UploadImagesValidation :AbstractValidator<UploadImagesCommand>
{

    public UploadImagesValidation()
    {

        RuleForEach(x => x.images)
            .NotEmpty()
            .NotNull()
            .Must(x=>FileRule.IsFile(x))
            .WithMessage("this field should be image");

    }
    
}