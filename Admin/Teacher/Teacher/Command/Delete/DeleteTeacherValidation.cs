using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Admin.Teacher.Teacher.Command.Delete;

public class DeleteTeacherValidation: AbstractValidator<DeleteTeacherCommand>
{

    public DeleteTeacherValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Teachers.IgnoreQueryFilters().Where(x=>x.DateDeleted==null).Any(x=>x.Id==id))
        .WithMessage("this teacher is not exists in our data");

    }


}
