using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Student.Command.Add;

public class AddStudentValidation: AbstractValidator<AddStudentCommand>
{

    public AddStudentValidation(ApplicationDbContext context){


        RuleFor(x=>x.Name)
        .NotEmpty()
        .NotNull();


        RuleFor(x=>x.ParentId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Parents.Any(x=>x.Id==id));

        RuleFor(x=>x.Email)
        .NotEmpty()
        .NotNull()
        .EmailAddress()
        .Must(email=>!context.Students.Any(x=>x.Email==email))
        .WithMessage("this email is already exists in our data");


        RuleFor(x=>x.Password)
        .NotEmpty()
        .NotNull()
        .MinimumLength(8);

        RuleFor(x=>x.Gender)
        .NotNull();

        // RuleFor(x=>x.ClassId)
        // .NotEmpty()
        // .NotNull()
        // .Must(id=>context.ClassYears.Any(x=>x.ClassId==id&&x.Status))
        // .WithMessage("this class id not exists in our data");


        RuleFor(x=>x.Level)
        .GreaterThan(0)
        .LessThanOrEqualTo(9);



    }

}
