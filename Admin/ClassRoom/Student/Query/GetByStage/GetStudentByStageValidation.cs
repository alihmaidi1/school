using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using infrastructure;

namespace Admin.ClassRoom.Student.Query.GetByStage;

public class GetStudentByStageValidation:  AbstractValidator<GetStudentByStageQuery>
{

    public GetStudentByStageValidation(ApplicationDbContext context){


        RuleFor(x=>x.Id)
        .NotEmpty()
        .NotNull()
        .Must(id=>context.Stages.Any(x=>x.Id==id))
        .WithMessage("this stage is not exists in our database");

    }

}
