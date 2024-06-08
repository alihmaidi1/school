using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.Student.Student.Query.GetAllStudentBill;

public class GetAllStudentBillValidation: AbstractValidator<GetAllStudentBillQuery>
{

    public GetAllStudentBillValidation(ApplicationDbContext context){

        RuleFor(x=>x.ClassId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Classes.Any(x=>x.Id==id))
        .WithMessage("this class is not exists in our data");


        RuleFor(x=>x.YearId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Years.Any(x=>x.Id==id))
        .WithMessage("this year is not exists in our data");

        RuleFor(x=>x.StudentId)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Students.Any(x=>x.Id==id))
        .WithMessage("this student is not exists in our data");





        
        

    }

}
