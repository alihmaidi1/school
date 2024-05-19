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
        .Must(id=>context.Questions.Any(x=>x.Id==id&&x.Quez.IsPending()))
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
        .Must(x=>x!=null&&context.Images.Any(y=>y.Id.Equals(x)))
        .When((request,x)=>request.Title==null&&context.Questions.Any(y=>y.Id==request.Id&&y.Image==null));

        
        RuleFor(x=>x.CorrectAnswer)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.Answers)
        .NotEmpty()
        .NotNull();

    }


}
