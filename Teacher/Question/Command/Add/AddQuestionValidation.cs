using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Question.Command.Add;

public class AddQuestionValidation: AbstractValidator<AddQuestionCommand>
{

    public AddQuestionValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


        RuleFor(x=>x.QuezId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id&&x.StartAt>DateTimeOffset.UtcNow&&x.SubjectYear.TeacherSubject.TeacherId==currentUserService.UserId))
        .WithMessage("this quez is active or not belongs to you");
        
        
        RuleFor(x=>x.ImageId)
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .When(x=>x.ImageId!=null);




        RuleFor(x=>x.Title)
        .NotNull()
        .When(x=>x.ImageId==null);




        RuleFor(x=>x.Score)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);


        RuleFor(x=>x.Time)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);

        RuleFor(x=>x.Answers)
        .NotNull()
        .NotEmpty();

        RuleFor(x=>x.CorrectAnswer)
        .NotEmpty()
        .NotNull();

    }

}
