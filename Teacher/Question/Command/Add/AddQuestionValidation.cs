using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Shared.Services.User;

namespace Teacher.Question.Command.Add;

public class AddQuestionValidation: AbstractValidator<AddQuestionCommand>
{

    public AddQuestionValidation(ApplicationDbContext context,ICurrentUserService currentUserService){


// x.IsBelongForId((Guid)currentUserService.UserId!)
    // x.Pending()
        RuleFor(x=>x.QuezId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Quezs.Any(x=>x.Id==id));
        
        
        RuleFor(x=>x.ImageId)
        .NotNull()
        .When(x=>x.Title==null)        
        .Must(id=>context.Images.Any(x=>x.Id==id))
        .When(x=>x.ImageId!=null);



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
