using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using FluentValidation;
using infrastructure;

namespace Teacher.Question.Command.Update;

public class UpdateQuestionValidation: AbstractValidator<UpdateQuestionCommand>
{

    public UpdateQuestionValidation(ApplicationDbContext context){

        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Questions.Any(x=>x.Id==id&&x.Quez.StartAt>DateTimeOffset.UtcNow))
        .WithMessage("this question is not exists or it is not pending");


        RuleFor(x=>x.Score)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);


        RuleFor(x=>x.Time)
        .NotEmpty()
        .NotNull()
        .GreaterThan(0);

        RuleFor(x=>x.ImageId)
        .Must(x=>context.Images.Any(y=>y.Id.Equals(x)))
        .When(x=>x.ImageId is not null)
        .WithMessage("this image is not exists in our data");


        RuleFor(x=>x.Title)
        .NotNull()
        .When(x=>x.ImageId is null&&context.Questions.Any(x=>x.Image==null&&x.Id==x.Id));


        
        RuleFor(x=>x.CorrectAnswer)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.Answers)
        .NotEmpty()
        .NotNull();

    }


}
